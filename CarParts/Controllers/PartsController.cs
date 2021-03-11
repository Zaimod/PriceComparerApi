using AutoMapper;
using CarParts.ModelBuilders;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts.Controllers
{
    [Route("api/parts")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private IMapper _mapper;

        public PartsController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllParts()
        {
            var parts = _repository.Parts.GetAllParts();

            _logger.LogInfo($"Returned all parts from database.");

            var partsResult = _mapper.Map<IEnumerable<PartsDto>>(parts);

            return Ok(partsResult);
        }

        [HttpGet("{id}", Name = "PartById")]
        public IActionResult GetPartById(Guid id)
        {
            var carPart = _repository.Parts.GetPartById(id);
            if (carPart == null)
            {
                _logger.LogInfo($"CarPart with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var carPartDto = _mapper.Map<PartsDto>(carPart);
                return Ok(carPartDto);
            }
        }

        [HttpGet("collection/({ids})", Name = "CarPartsCollection")]
        public IActionResult GetPartsCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parametr ids is null");
            }

            var carPartsEntities = _repository.Parts.GetByIds(ids);

            if (ids.Count() != carPartsEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            var carPartsToReturn = _mapper.Map<IEnumerable<PartsDto>>(carPartsEntities);

            return Ok(carPartsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarParts([FromBody] PartsForCreationDto parts)
        {
            if (parts == null)
            {
                _logger.LogError("PartsForCreationDto object sent from client is null.");

                return BadRequest("PartsForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid car object sent from client.");

                return BadRequest("Invalid model object");
            }

            var carPartsEntity = _mapper.Map<Parts>(parts);

            _repository.Parts.CreateParts(carPartsEntity);
            await _repository.SaveAsync();

            var carPartsToReturn = _mapper.Map<PartsDto>(carPartsEntity);

            return CreatedAtRoute("CarPartsById", new { id = carPartsToReturn.Id }, carPartsToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreatePartsCollection([FromBody] IEnumerable<PartsForCreationDto> partsCollection)
        {
            if (partsCollection == null)
            {
                _logger.LogError("Parts collection sent from client is null");
                return BadRequest("Parts collection is null");
            }

            var partsEntities = _mapper.Map<IEnumerable<Parts>>(partsCollection);
            foreach (var parts in partsEntities)
            {
                _repository.Parts.CreateParts(parts);
            }

            await _repository.SaveAsync();

            var partsCollectionToReturn = _mapper.Map<IEnumerable<PartsDto>>(partsEntities);
            var ids = string.Join(",", partsCollectionToReturn.Select(c => c.Id));

            return CreatedAtRoute("PartsCollection", new { ids }, partsCollectionToReturn);
        }
    }
}
