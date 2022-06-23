using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.LMS.Models;

namespace LMS.Interface
{
    public interface IUserManager
    {
        public void RentBook(string name, string bookname, int phone, int days, int bookid);

        public List<UserEntity> GetList();

        public void RemoveRent(int id);

    }
}
