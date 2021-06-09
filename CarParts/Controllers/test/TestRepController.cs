using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts.Controllers.test
{
    [ApiController]
    [Route("testRep")]
    public class testRepController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="testRepController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public testRepController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _repository.catalog.FindAll();
            _repository.store.FindAll();

            return new string[] { "test1", "test2" };
        }
    }
}
