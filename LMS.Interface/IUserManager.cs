using LMS.Models.Dto;
using LMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Interface
{
    public interface IUserManager
    {
        public void Create(CreateUserRequest user);
        public void Update(int id, User user);
        public void Delete(int id);
        public User GetUser(int id);

    }
}
