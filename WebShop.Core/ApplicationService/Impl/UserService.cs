using System;
using WebShop.Core.DomainService;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public User CreateCustomer(User user)
        {
            if (user.Customer == null){
                user.Customer = new Customer();
            }

            return _UserRepository.AddUser(user);
        }

        public User CreateEmployee(User user)
        {
            if (user.Employee == null)
            {
                user.Employee = new Employee();
            }

            return _UserRepository.AddUser(user);
        }

        public User Delete(User user)
        {
            return _UserRepository.Delete(user);
        }

        public User GetUserById(int id)
        {
            return _UserRepository.GetUserById(id);
        }

        public User Login(User user)
        {
            User loggedIn = _UserRepository.GetUserByUsername(user.Username);

            if (loggedIn == null || !loggedIn.PasswordHash.Equals(user.PasswordHash))
            {
                throw new ArgumentException("The Username and/or Password was not correct");
            }

            return loggedIn;
        }

        public User Update(User user)
        {
            User userUpdated = _UserRepository.UpdateUser(user);
            return userUpdated;
        }
    }
}
