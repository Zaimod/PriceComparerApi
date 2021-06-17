using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarParts.ActionFilters;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PriceComparer.Controllers
{
    [Route("api/favouriteitem")]
    [ApiController]
    public class FavouriteItemController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private IMapper _mapper;

        public FavouriteItemController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateFavouriteItem([FromBody] FavouriteItemForCreationDto favouriteItem)
        {
            if (favouriteItem == null)
            {
                _logger.LogError("FavouriteItemForCreationDto object sent from client is null.");

                return BadRequest("FavouriteItemForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid favourite Item object sent from client.");

                return BadRequest("Invalid model object");
            }

            var favouriteItemMapped = _mapper.Map<FavouriteItem>(favouriteItem);

            _repository.favouriteItem.AddFavouriteItem(favouriteItemMapped);

            await _repository.SaveAsync();

            return Ok();
        }

        [HttpGet("userName/{id}", Name = "FavouriteItemsByUserName")]
        public async Task<IActionResult> GetFavouriteItemsByUserName(string id)
        {
            var favouriteItems = await _repository.favouriteItem.GetFavouriteItemsByUser(id);

            _logger.LogInfo($"Returned all favourite items by username from database.");

            var resultFavouriteItems = _mapper.Map<IEnumerable<FavouriteItemDto>>(favouriteItems);
 
            return Ok(resultFavouriteItems);
        }
    }
}
