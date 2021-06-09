using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PriceComparer.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ProductController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.product.GetAllProducts();

            _logger.LogInfo($"Returned all products from database.");

            var productsResult = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productsResult);
        }

        /// <summary>
        /// Gets the catalogt by category identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("byCategoryId/{id}", Name = "productsByCategoryId")]
        public async Task<IActionResult> GetCatalogtByCategoryId(int id)
        {
            var products = await _repository.product.GetProductsByCategoryId(id);
            if (products == null)
            {
                _logger.LogInfo($"Products with CategoryId: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var productsResult = _mapper.Map<IEnumerable<ProductDto>>(products);
                return Ok(productsResult);
            }
        }

    }
}
