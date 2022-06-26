using LMS.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Interface
{
    public interface IUserManager
    {
        //crud operations
        public User create(User user, int days);
        public User update(int id, User user);
        public void remove(int id, User user);
        public object GetUser(int id);

    }
}
