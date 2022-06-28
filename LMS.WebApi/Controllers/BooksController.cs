using LMS.Interface;
using LMS.Models.Dto;
using LMS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace LMS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        ILogger<BooksController> _logger;

        IBookManager _bookService;
        public BooksController(IBookManager bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddBook(CreateBookRequest book)
        {
            try
            {
                _bookService.Create(book);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult UpdateBook(int id,Book book)
        {
            try
            {
                _bookService.Update(id,book);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }

        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _bookService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }

        }


        [HttpGet]
        public IActionResult GetBook(int id)
        {
            try
            {
                Book book = _bookService.GetBook(id);
                if (book == null) { return NotFound(); }
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }

        }

            [HttpPut]
            public IActionResult ChangeCopies(int id, string opp)
            {
               try
                {
                    _bookService.CopiesChange(id, opp);
                    return Ok();
                }
                catch (Exception ex)
                {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
               }

            }
                      
    }
}
