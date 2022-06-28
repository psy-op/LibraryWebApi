using LMS.Interface;
using LMS.Mapping;
using LMS.Models.Dto;
using Microsoft.Extensions.Logging;
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
       // ClassMapper _mapper;
        ClassMapper _mapper = new ClassMapper();
        ILogger<BookSqlManager> _logger;
        private EFContext dbContext;
        public BookSqlManager(EFContext context, ILogger<BookSqlManager> logger/*, ClassMapper mapper*/)
        {
           this.dbContext = context;
            _logger = logger;
            //_mapper = mapper;  
        }

        public void Create(CreateBookRequest book)
        {
            try
            {
                dbContext.Book.Add(_mapper.Map(book));
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }

        public void Update(int id,Book book)
        {
            try
            {
                var bookentity = dbContext.Book.FirstOrDefault(book => book.ID == id);
                if (bookentity == null ) { return; }
                else 
                { 
                    bookentity.Author= book.Author;
                    bookentity.Title= book.Title;
                    bookentity.Copies = book.Copies;

                    dbContext.Book.Update(bookentity); 
                }
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }

        public void Delete(int id)
        {
            try
            {
                var bookentity = dbContext.Book.FirstOrDefault(book => book.ID == id);
                if (bookentity == null) { return; }
                else { dbContext.Book.Remove(bookentity); }
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }

        public Book GetBook(int id)
        {
            try
            {
                var bookentity = dbContext.Book.FirstOrDefault(book => book.ID == id);
                if (bookentity == null) { return null; }
                else { return _mapper.Map(bookentity); }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return null;
                
            }

        }

        
        public void CopiesChange(int id, string opp)
        {
            try
            {               
                var bookentity = dbContext.Book.FirstOrDefault(book => book.ID == id);
                if (bookentity == null) { return ; }
                else if (opp == "-") { bookentity.Copies--; }
                else if (opp == "+") { bookentity.Copies++; }
                else { return ; }
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }

    }
}