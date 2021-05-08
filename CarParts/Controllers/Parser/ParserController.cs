using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParserApplication;
using ParserApplication.Parsers.Rozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts.Controllers.Parser
{
    [Route("parser/")]
    [ApiController]
    public class ParserController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private IMapper _mapper;
        private IParser _parser;
        private IEnumerable<CatalogForCreationDto> dto;

        public ParserController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet("test")]
        public async Task<IActionResult> Test(string search = "iphone", int storeId = 1, int categoryId = 1, int productId = 1)
        {
            _logger.LogInfo($"Testing Parser Controller");

            _parser = new ParserRozetka(storeId, categoryId, productId, _repository);

            dto = await _parser.Run(search);

            return Ok(dto);
        }

        [HttpGet("insert")]
        public async Task<IActionResult> Insert(string search = "iphone", int storeId = 1, int categoryId = 1, int productId = 1)
        {
            _logger.LogInfo($"Insert date Controller");

            _parser = new ParserRozetka(storeId, categoryId, productId, _repository);

            dto = await _parser.Run(search);
            var itemsEntities = _mapper.Map<IEnumerable<Catalog>>(dto);

            foreach (var item in itemsEntities)
            {
                if (_repository.catalog.GetItemOfCatalogByName(item.Name) == null)
                {
                    _repository.catalog.CreateCatalog(item);
                }
            }

            await _repository.SaveAsync();

            return Ok(dto);
        }
    }
}
