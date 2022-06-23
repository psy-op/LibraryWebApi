using LMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.LMS.Models;

namespace LMS.BL.DI
{
    public class Book : IBookManager
    {
        public List<BookEntity> GetList()
        {
            return null;
        }

        public string GetBook(int id)
        {

        }

        public void CopiesDecrement(int id)
        {

        }

        public void Copiesincrement(int id)
        {

        }
    }
}
