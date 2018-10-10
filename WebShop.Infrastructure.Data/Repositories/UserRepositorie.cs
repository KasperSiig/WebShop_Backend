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

        public User AddCustomer(User user)
        {
            var userSaved = _ctx.Add(user).Entity;
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
            return _ctx.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _ctx.Users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public User UpdateUser(User user)
        {
            _ctx.Attach(user).State = EntityState.Modified;
            _ctx.Entry(user).Reference(u => u.customer).IsModified = true;
            _ctx.Entry(user).Reference(u => u.employee).IsModified = true;
            _ctx.SaveChanges();

            return user;
        }
    }
}
