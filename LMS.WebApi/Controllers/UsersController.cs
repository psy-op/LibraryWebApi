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
    

    public class UsersController : ControllerBase
    {
        ILogger<BooksController> _logger;
        IUserManager _userService;
        public UsersController(IUserManager userService, ILogger<BooksController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult AddUser(CreateUserRequest user)
        {
            try
            {
                _userService.Create(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult UpdateUser(int id, User user)
        {
            try
            {
                _userService.Update(id, user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }

        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }

        }


        [HttpGet]
        public IActionResult GetUser(int id)
        {
            try
            {
                User user = _userService.GetUser(id);
                if(user == null) { return NotFound(); }
                return Ok(user);
                //try null for bookentity
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }

        }

    }

}
