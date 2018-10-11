using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.DomainService;
using WebShop.Core.Entity;

namespace WebShop.Infrastructure.Data.Repositories
{
    public class UserRepositorie : IUserRepository
    {
        private readonly WebShopContext _ctx;

        public UserRepositorie(WebShopContext ctx)
        {
            _ctx = ctx;
        }

        public User AddUser(User user)
        {
            var userSaved = _ctx.Add(user).Entity;

            var entries = _ctx.ChangeTracker.Entries();

            _ctx.SaveChanges();

            return userSaved;
        }

        public User Delete(User user)
        {
            var removed = _ctx.Remove(user).Entity;
            _ctx.SaveChanges();
            return removed;
        }

        public User GetUserById(int id)
        {
            return _ctx.Users
                       .Include(u => u.Customer)
                       .Include(u => u.Employee)
                       .FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _ctx.Users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public User UpdateUser(User user)
        {
            _ctx.Attach(user).State = EntityState.Modified;
            _ctx.Entry(user).Reference(u => u.Customer).IsModified = true;
            _ctx.Entry(user).Reference(u => u.Employee).IsModified = true;
            _ctx.SaveChanges();

            return user;
        }
    }
}
