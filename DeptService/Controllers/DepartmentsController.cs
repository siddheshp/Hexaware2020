using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Models;
using EMS.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeptService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IRepository<Department> repository;

        public DepartmentsController(IRepository<Department> repository)
        {
            this.repository = repository;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return repository.Get();
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
