using LMS.BL.DI;
using LMS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.LMS.DAL.EF;

namespace LMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class UsersController : ControllerBase
    {
        IUserManager _userManager;
        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }   
    }

}
