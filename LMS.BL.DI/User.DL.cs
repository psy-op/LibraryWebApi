using LMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.LMS.Models;

namespace LMS.BL.DI
{
    public class User: IUserManager
    {

        public List<UserEntity> GetList()
        {
            return null;
        }


        public void RentBook(string name, string bookname, int phone, int days, int bookid)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(days));

        }




        public void RemoveRent(int id)
        {

        }

    }
}
