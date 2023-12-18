using BookCRUDAPIForAngular.Model;
using BookCRUDAPIForAngular.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCRUDAPIForAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService services;
        public StudentController(IStudentService services)
        {
            this.services = services;
        }

        // GET: api/<BookController>
        [HttpGet]
        [Route("GetStudents")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await services.GetStudents();
                return new ObjectResult(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // GET api/<BookController>/5
        [HttpGet]
        [Route("GetStudentById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await services.GetStudentById(id);
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
        [Route("AddStudent")]

        public async Task<IActionResult> Post([FromBody][Bind(include: "Name,Percentage,City")] Student stud)// from body of HTTP

        {

            try
            {
                int result = await services.AddStudent(stud);
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
        [Route("UpdateStudent")]
        public async Task<IActionResult> Put([FromBody] Student stud)

        {
            try
            {
                int result = await services.UpdateStudent(stud);
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
        [Route("DeleteStudent/{id}")]


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int result = await services.DeleteStudent(id);
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
