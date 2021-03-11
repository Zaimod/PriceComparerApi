using AutoMapper;
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
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private IMapper _mapper;

        public CarsController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllOwners"), Authorize]
        public async Task<IActionResult> GetAllOwners()
        {
            var cars = await _repository.Cars.GetAllCarsAsync();

            _logger.LogInfo($"Returned all cars from database.");

            var carsResult = _mapper.Map<IEnumerable<CarsDto>>(cars);

            return Ok(carsResult);
        }

        [HttpGet("{id}", Name = "CarById")]
        public async Task<IActionResult> GetCarById(Guid id)
        {
            var car = await _repository.Cars.GetCarByIdAsync(id);
            if (car == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var carDto = _mapper.Map<CarsDto>(car);
                return Ok(carDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody]CarForCreationDto car)
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

            var carEntity = _mapper.Map<Cars>(car);

            _repository.Cars.CreateCar(carEntity);
            await _repository.SaveAsync();

            var createdCar = _mapper.Map<CarsDto>(carEntity);

            return CreatedAtRoute("CarById", new { id = createdCar.Id }, createdCar);
        }
    }
}
