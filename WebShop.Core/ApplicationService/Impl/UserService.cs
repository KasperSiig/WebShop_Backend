using WebShop.Core.DomainService;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public User CreateCustomer(User user)
        {
            return _userRepo.Create(user);
        }
        
        public User CreateEmployee(User user)
        {
            return _userRepo.Create(user);
        }

        public User GetUser(int id)
        {
            return _userRepo.ReadUser(id);
        }
    }
}