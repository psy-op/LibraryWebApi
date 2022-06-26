using LMS.Interface;
using LMS.Models.Dto;
using LMS.Models.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.LMS.DAL.EF;

namespace LMS.BL.DI
{
    public class BookSqlManager : IBookManager
    {
        private EFContext dbContext;
        public BookSqlManager(EFContext context)
        {
           this.dbContext = context;
        }

        public void Create(BookEntity book)
        {
            dbContext.Add(book);
            dbContext.SaveChanges();
        }

        public void Update(int id,Book book)
        {
            var query = from b in dbContext.Book
                        select b;

            foreach (var item in query)
            {
                if (item.ID == id)
                {
                    item.Title = book.Title; 
                    item.Author = book.Author;
                    item.Copies = book.Copies;
                    dbContext.Update(item);              
                };
            }
            dbContext.SaveChanges();      
        }

        public void Delete(int id)
        {
            var query = from b in dbContext.Book
                        select b;

            foreach (var item in query)
            {
                if (item.ID == id) { dbContext.Remove(item); }
            }
            dbContext.SaveChanges();
        }

        public object GetBook(int id)
        {
            var query = from b in dbContext.Book
                        select b;

                foreach (var item in query)
                {
                    if (item.ID == id){return item;}
                    else { return null; }
                }
            return null;
            
        }

        public void CopiesChange(int id, string opp)
        {
            var query = from b in dbContext.Book                           
                select b ;

            foreach (var item in query)
            {
                if (item.ID == id)
                {
                    if (opp == "+") { item.Copies++; }
                    else if (opp == "-") { item.Copies--; }
                    else { break; }
                    dbContext.Update(item);
                    
                    
                };

            }
            dbContext.SaveChanges();
        }


    }
}
