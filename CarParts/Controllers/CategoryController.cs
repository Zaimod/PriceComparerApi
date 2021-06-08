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

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CategoryController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _repository.category.GetAllCategories();

            _logger.LogInfo($"Returned all categories from database.");

            var categoriesResult = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoriesResult);
        }

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "CategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _repository.category.GetCategoryById(id);
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

        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
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

            _repository.category.CreateCategory(categoryEntity);
            await _repository.SaveAsync();

            var createdCategory = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
        }
    }
}
