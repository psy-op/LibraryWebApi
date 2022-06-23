using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.LMS.DAL.EF;
using Testing.LMS.Models;


namespace LMS.EF.Test
{
    class Console
    {
        static void Main(string[] args)
        {

            using(var dbContext = new EFContext())
            {
                
                //var book = new BookEntity() { Author = "Leo",Title="Bk3",Copies=4};
                //dbContext.Book.Add(book);
                //dbContext.SaveChanges();

                //var books = dbContext.Book.FirstOrDefault(b => b.ID == 2);
                //dbContext.Remove(books);
                //dbContext.SaveChanges();

            }

        }

    }
}
