using BookCRUDAPIForAngular.Model;
using BookCRUDAPIForAngular.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCRUDAPIForAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService services;
        public BookController(IBookService services)
        {
            this.services = services;
        }

        // GET: api/<BookController>
        [HttpGet]
        [Route("GetBooks")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await services.GetBooks();
                return new ObjectResult(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // GET api/<BookController>/5
        [HttpGet]
        [Route("GetBookById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await services.GetBookById(id);
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
        [Route("AddBook")]

        public async Task<IActionResult> Post([FromBody] [Bind(include:"Name,Author,Price")] Book book)// from body of HTTP

        {

            try
            {
                int result = await services.AddBook(book);
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
        [Route("UpdateBook")]
        public async Task<IActionResult> Put([FromBody] Book book)

        {
            try
            {
                int result = await services.UpdateBook(book);
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
        [Route("DeleteBook/{id}")]


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int result = await services.DeleteBook(id);
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

