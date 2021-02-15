using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IRepositoryManager _repository; 
        private readonly ILoggerManager _logger; 
        private readonly IMapper _mapper;

        public SuppliersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            var suppliers = _repository.Suppliers.GetAllSuppliers();

            _logger.LogInfo($"Returned all suppliers from database.");

            var supliersResult = _mapper.Map<IEnumerable<SuppliersDto>>(suppliers);

            return Ok(supliersResult);
        }

        [HttpGet("{id}", Name = "SupplierById")]
        public IActionResult GetSupplierById(Guid id)
        {
            var supplier = _repository.Suppliers.GetSupplierById(id);
            if (supplier == null)
            {
                _logger.LogInfo($"Supplier with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var supplierDto = _mapper.Map<SuppliersDto>(supplier);
                return Ok(supplierDto);
            }
        }
    }
}
