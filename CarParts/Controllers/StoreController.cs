using AutoMapper;
using CarParts.ActionFilters;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts.Controllers
{

    [Route("api/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public StoreController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all owners.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllStories"), Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetAllOwners()
        {
            var cars = await _repository.store.GetStoresAsync();

            _logger.LogInfo($"Returned all cars from database.");

            var carsResult = _mapper.Map<IEnumerable<StoreDto>>(cars);

            return Ok(carsResult);
        }

        /// <summary>
        /// Gets the store by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "StoreById")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            var car = await _repository.store.GetStoreByIdAsync(id);
            if (car == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var carDto = _mapper.Map<StoreDto>(car);
                return Ok(carDto);
            }
        }

        /// <summary>
        /// Creates the store.
        /// </summary>
        /// <param name="car">The car.</param>
        /// <returns></returns>
        [HttpPost(Name = "CreateStore")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateStore([FromBody]StoreForCreationDto car)
        {
            if(car == null)
            {
                _logger.LogError("CarForCreationDto object sent from client is null.");

                return BadRequest("CarForCrationDto object is null");
            }

            if(!ModelState.IsValid)
            {
                _logger.LogError("Invalid car object sent from client.");

                return BadRequest("Invalid model object");
            }

            var carEntity = _mapper.Map<Store>(car);

            _repository.store.CreateStore(carEntity);
            await _repository.SaveAsync();

            var createdCar = _mapper.Map<StoreDto>(carEntity);

            return CreatedAtRoute("StoreById", new { id = createdCar.Id }, createdCar);
        }
    }
}
