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
    [Route("api/catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private IMapper _mapper;

        public CatalogController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCatalog()
        {
            var parts = _repository.catalog.GetCatalog();

            _logger.LogInfo($"Returned all catalogs from database.");

            var partsResult = _mapper.Map<IEnumerable<CatalogDto>>(parts);

            return Ok(partsResult);
        }

        [HttpGet("{id}", Name = "CatalogById")]
        public IActionResult GetCatalogtById(int id)
        {
            var carPart = _repository.catalog.GetItemOfCatalogById(id);
            if (carPart == null)
            {
                _logger.LogInfo($"CarPart with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var carPartDto = _mapper.Map<CatalogDto>(carPart);
                return Ok(carPartDto);
            }
        }

        [HttpGet("collection/({ids})", Name = "CatalogCollection")]
        public IActionResult GetCatalogCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parametr ids is null");
            }

            var carPartsEntities = _repository.catalog.GetByIds(ids);

            if (ids.Count() != carPartsEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            var carPartsToReturn = _mapper.Map<IEnumerable<CatalogDto>>(carPartsEntities);

            return Ok(carPartsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalog([FromBody] CatalogForCreationDto catalog)
        {
            if (catalog == null)
            {
                _logger.LogError("PartsForCreationDto object sent from client is null.");

                return BadRequest("PartsForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid car object sent from client.");

                return BadRequest("Invalid model object");
            }

            var carPartsEntity = _mapper.Map<Catalog>(catalog);

            _repository.catalog.CreateCatalog(carPartsEntity);
            await _repository.SaveAsync();

            var carPartsToReturn = _mapper.Map<CatalogDto>(carPartsEntity);

            return CreatedAtRoute("CarPartsById", new { id = carPartsToReturn.id }, carPartsToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCatalogCollection([FromBody] IEnumerable<CatalogForCreationDto> partsCollection)
        {
            if (partsCollection == null)
            {
                _logger.LogError("Catalog collection sent from client is null");
                return BadRequest("Catalog collection is null");
            }

            var partsEntities = _mapper.Map<IEnumerable<Catalog>>(partsCollection);
            foreach (var parts in partsEntities)
            {
                _repository.catalog.CreateCatalog(parts);
            }

            await _repository.SaveAsync();

            var partsCollectionToReturn = _mapper.Map<IEnumerable<CatalogDto>>(partsEntities);
            var ids = string.Join(",", partsCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("CatalogCollection", new { ids }, partsCollectionToReturn);
        }
    }
}
