using LMS.Interface;
using LMS.Mapping;
using LMS.Models.Dto;
using LMS.Models.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.LMS.DAL.EF;

namespace LMS.BL.DI
{
    public class UserSqlManager: IUserManager
    {
        //ClassMapper _mapper;
        ClassMapper _mapper = new ClassMapper();

        ILogger<UserSqlManager> _logger;
        private EFContext dbContext;
        public UserSqlManager(EFContext context, ILogger<UserSqlManager> logger/*,ClassMapper mapper*/)
        {
            this.dbContext = context;
            _logger = logger;
            //_mapper = mapper;           
        }

        public void Create(CreateUserRequest user)
        {
            try
            {               
                var bookentity = dbContext.Book.FirstOrDefault(book => book.ID == user.BookId);
                if (bookentity == null || bookentity.Copies <= 0) { return; }
               
                user.BookId = bookentity.ID;
                dbContext.User.Add(_mapper.Map(user));
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

        }

        public User GetUser(int id)
        {
            try
            {
                var userentity = dbContext.User.FirstOrDefault(user => user.ID == id);
                if (userentity == null) { return null; }
                else { return _mapper.Map(userentity); }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return null;
                
            }
        }

        public void Delete(int id)
        {
            try
            {
                var userentity = dbContext.User.FirstOrDefault(user => user.ID == id);
                if (userentity == null) { return; }
                else { dbContext.User.Remove(userentity); }
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }

        public void Update(int id, User user)
        {
            try
            {
                var userentity = dbContext.User.FirstOrDefault(user => user.ID == id);
                if (userentity == null) { return; }
                else 
                {
                    userentity.Phone = user.Phone;
                    userentity.Name = user.Name;
                    userentity.BookId = user.BookId;
                    userentity.SDate = user.SDate;
                    userentity.EDate = user.EDate;
                    userentity.book = _mapper.Map(user.book);
                    dbContext.User.Update(userentity); 
                }
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }
    }
}
