using LMS.Interface;
using LMS.Models.Dto;
using LMS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookManager _bookService;
        public BooksController(IBookManager bookService)
        {
            _bookService = bookService;
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult AddBook(BookEntity book)
        {
            try
            {
                _bookService.Create(book);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateBook(int id,Book book)
        {
            try
            {
                _bookService.Update(id,book);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _bookService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetBook(int id)
        {
            try
            {
                _bookService.GetBook(id);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

            [HttpPut]
            [Route("[action]")]
            public IActionResult ChangeCopies(int id, string opp)
            {
               try
                {
                    _bookService.CopiesChange(id, opp);
                                    return Ok();
                }
                catch (Exception)
                {
                   return BadRequest();
               }

            }


        
    }
}
