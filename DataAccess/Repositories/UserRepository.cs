using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context)
            :base(context)
        {
        }

        public bool IsAuthentic(string username, string password)
        {
            var user = AppDbContext.Users
                .Where(u => u.UserName == username && u.Password == password)
                .FirstOrDefault();

            return (user == null) ? false : true;
        }

        public bool IsAdmin(string username)
        {
            var user = AppDbContext.Users
                .Where(u => u.UserName == username && u.IsAdmin == true)
                .FirstOrDefault();

            return (user == null) ? false : true;
        }

        private AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}