using AutoMapper;
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
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private IMapper _mapper;

        public CategoryController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _repository.Category.GetAllCategories();

            _logger.LogInfo($"Returned all categories from database.");

            var categoriesResult = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoriesResult);
        }

        [HttpGet("{id}", Name = "CategoryById")]
        public IActionResult GetCategoryById(Guid id)
        {
            var category = _repository.Category.GetCategoryById(id);
            if (category == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return Ok(categoryDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
        {
            if (category == null)
            {
                _logger.LogError("CategoryForCreationDto object sent from client is null.");

                return BadRequest("CategoryForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid car object sent from client.");

                return BadRequest("Invalid model object");
            }

            var categoryEntity = _mapper.Map<Category>(category);

            _repository.Category.CreateCategory(categoryEntity);
            await _repository.SaveAsync();

            var createdCategory = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
        }
    }
}
