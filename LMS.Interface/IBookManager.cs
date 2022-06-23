using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.LMS.Models;

namespace LMS.Interface
{
    public interface IBookManager
    {
        public List<BookEntity> GetList();
        public string GetBook(int id);
        public void CopiesDecrement(int id);
        public void Copiesincrement(int id);

    }
}