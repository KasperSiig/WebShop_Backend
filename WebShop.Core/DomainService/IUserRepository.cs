using WebShop.Core.Entity;

namespace WebShop.Core.DomainService
{
    public interface IUserRepository
    {
        User Create(User user);
        User ReadUserById(int id);
        User Update(User user);
        User Delete(User user);
    }
}