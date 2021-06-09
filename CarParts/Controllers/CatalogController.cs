using AutoMapper;
using CarParts.ModelBuilders;
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
    [Authorize]
    [Route("api/catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CatalogController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all catalog.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCatalog()
        {
            var parts = await _repository.catalog.GetCatalog();

            _logger.LogInfo($"Returned all catalogs from database.");

            var partsResult =  _mapper.Map<IEnumerable<CatalogDto>>(parts);

            return Ok(partsResult);
        }

        /// <summary>
        /// Gets the catalog by search.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("search/{id}", Name = "CatalogBySearch")]
        public async Task<IActionResult> GetCatalogBySearch(string id)
        {
            var catalog = await _repository.catalog.GetCatalogBySearch(id);

            _logger.LogInfo($"Returned all catalogs by search string from database.");

            var catalogResult = _mapper.Map<IEnumerable<CatalogDto>>(catalog);

            return Ok(catalogResult);
        }

        /// <summary>
        /// Gets the catalog by product identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("productId/{id}", Name = "CatalogByProductId")]
        public async Task<IActionResult> GetCatalogByProductId(int id)
        {
            var catalog = await _repository.catalog.GetCatalogByProductId(id);

            _logger.LogInfo($"Returned all catalogs by product id from database.");

            var catalogResult = _mapper.Map<IEnumerable<CatalogDto>>(catalog);

            return Ok(catalogResult);
        }

        /// <summary>
        /// Gets the catalogt by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the catalog collection.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates the catalog.
        /// </summary>
        /// <param name="catalog">The catalog.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates the catalog collection.
        /// </summary>
        /// <param name="partsCollection">The parts collection.</param>
        /// <returns></returns>
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
