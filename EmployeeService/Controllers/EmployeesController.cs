using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Models;
using EmployeeService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IRepository<Employee> repository;
        public EmployeesController(IRepository<Employee> repository)
        {
            this.repository = repository;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return repository.Get();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult<Employee> Post([FromForm] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isAdded = repository.Add(employee);
                    if (isAdded)
                    {
                        return Created("employees", employee);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                //throw;
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromForm] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == employee.Id)
                    {
                        var existing = repository.Get(id);
                        if (existing == null)
                        {
                            return NotFound("Employee does not exist");
                        }
                        var isUpdated = repository.Update(employee);
                        if (isUpdated)
                        {
                            return Ok("Updated scuccessfully");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError);
                        }
                    }
                    else
                    {
                        return BadRequest("id do not match");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
