using LMS.Interface;
using LMS.Models.Dto;
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
        private EFContext dbContext;
        public UserSqlManager(EFContext context)
        {
            this.dbContext = context;
        }

        public User create(User user,int days)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = sDate.AddDays(Convert.ToDouble(days));
            user.SDate = Convert.ToString(sDate);
            user.EDate = Convert.ToString(eDate);
            dbContext.Add(user) ;
            dbContext.SaveChanges();
            return user;
            
        }

        public object GetUser(int id)
        {
            var query = from b in dbContext.User
                        select b;

            foreach (var item in query)
            {
                if (item.ID == id) { return item; }
                else { return null; }
            }
            return null;
        }

        public void remove(int id, User user)
        {
            var query = from b in dbContext.User
                        select b;

            foreach (var item in query)
            {
                if (item.ID == id) { dbContext.Remove(item); dbContext.SaveChanges(); }
            }
        }

        public User update(int id, User user)
        {
            var query = from b in dbContext.User
                        select b;

            foreach (var item in query)
            {
                if (item.ID == id)
                {
                    dbContext.Update(user);
                    dbContext.SaveChanges();
                    return user;
                };
                return null;
            }
            return null;
        }
    }
}
