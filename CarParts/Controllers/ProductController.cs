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

        public ProductController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.product.GetAllProducts();

            _logger.LogInfo($"Returned all products from database.");

            var productsResult = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productsResult);
        }

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
