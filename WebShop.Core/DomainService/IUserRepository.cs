using System;
using WebShop.Core.Entity;

namespace WebShop.Core.DomainService
{
    public interface IUserRepository
    {
        User AddCustomer(User user);
        User Delete(User user);
        User GetUserById(int id);
        User GetUserByUsername(string username);
        User UpdateUser(User user);
    }
}
