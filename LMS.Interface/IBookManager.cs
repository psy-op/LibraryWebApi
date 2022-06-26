using LMS.Models.Dto;
using LMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Interface
{
    public interface IBookManager
    {
        //crud operations
        // bookdto create(bookdto)
        //delete book (dont show user if copies 0)
        //update book
        public void Create(BookEntity book);
        public void Update(int id, Book book);
        public void Delete(int id);
        public object GetBook(int id);
        public void CopiesChange(int id,string opp);

    }
}