using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService
{
    public interface IUserService
    {
        User CreateCustomer(User user);
        User CreateEmployee(User user);
        User GetUserById(int id);
        User Update(User user);
        User Delete(User user);
    }
}