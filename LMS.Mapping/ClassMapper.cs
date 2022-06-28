using LMS.Models.Dto;
using LMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Mapping
{
    public class ClassMapper
    {
        public Book Map(BookEntity book)
        {
            var temp = new Book
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Copies = book.Copies
            };
            return temp;
        }

        public BookEntity Map(Book book)
        {
            var temp = new BookEntity
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Copies = book.Copies
            };
            return temp;
        }


        public User Map(UserEntity user)
        {
            var temp = new User
            {
                SDate = user.SDate,
                EDate = user.EDate,
                Name = user.Name,
                Phone = user.Phone,
                BookId = user.BookId
            };
            var temp2 = new ClassMapper();
            temp.book = temp2.Map(user.book);
            return temp;
        }

        public UserEntity Map(User user)
        {
            var temp = new UserEntity
            {
                SDate = user.SDate,
                EDate = user.EDate,
                Name = user.Name,
                Phone = user.Phone,
                BookId = user.BookId
            };
            var temp2 = new ClassMapper();
            temp.book = temp2.Map(user.book);
            return temp;
        }


        public UserEntity Map(CreateUserRequest user)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(user.Days));
            var temp = new UserEntity
            {
                SDate = Convert.ToString(sDate),
                EDate = Convert.ToString(eDate),
                Name = user.Name,
                Phone = user.Phone,
                BookId = user.BookId
            };
            return temp;
        }

        public BookEntity Map(CreateBookRequest book)
        {
            var temp = new BookEntity
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Copies = book.Copies
            };
            return temp;
        }


    }
}