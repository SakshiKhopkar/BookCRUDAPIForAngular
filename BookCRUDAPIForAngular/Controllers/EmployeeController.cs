using BookCRUDAPIForAngular.Model;
using BookCRUDAPIForAngular.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCRUDAPIForAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService services;
        public EmployeeController(IEmployeeService services)
        {
            this.services = services;
        }

        // GET: api/<BookController>
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await services.GetEmployees();
                return new ObjectResult(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // GET api/<BookController>/5
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await services.GetEmployeeById(id);
                if (model != null)
                    return new ObjectResult(model);
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // POST api/<BookController>
        [HttpPost]
        [Route("AddEmployee")]

        public async Task<IActionResult> Post([FromBody][Bind(include: "Name,Email,Age,Salary")] Employee emp)// from body of HTTP

        {

            try
            {
                int result = await services.AddEmployee(emp);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }

        // PUT api/<BookController>/5
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put([FromBody] Employee emp)

        {
            try
            {
                int result = await services.UpdateEmployee(emp);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        // DELETE api/<BookController>/5
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int result = await services.DeleteEmployee(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


    }
}

