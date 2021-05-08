﻿using Contracts;
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

        public testRepController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _repository.catalog.FindAll();
            _repository.store.FindAll();

            return new string[] { "value1", "value2" };
        }
    }
}
