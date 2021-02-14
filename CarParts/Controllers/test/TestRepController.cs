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
        private readonly IRepositoryWrapper _repository;

        public testRepController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _repository.Cars.FindAll();
            _repository.Suppliers.FindAll();

            return new string[] { "value1", "value2" };
        }
    }
}
