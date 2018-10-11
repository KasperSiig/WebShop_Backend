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

            var returnedUser = _UserRepository.AddUser(user);

            returnedUser.PasswordHash = null; //because we dont like to send hashed passwords over the inthernet when it is not needed

            return returnedUser;
        }

        public User CreateEmployee(User user)
        {
            if (user.Employee == null)
            {
                user.Employee = new Employee();
            }

            var returnedUser = _UserRepository.AddUser(user);

            returnedUser.PasswordHash = null;

            return returnedUser;
        }

        public User Delete(User user)
        {
            var returnedUser = _UserRepository.Delete(user);

            returnedUser.PasswordHash = null;

            return returnedUser;

        }

        public User GetUserById(int id)
        {
            var returnedUser = _UserRepository.GetUserById(id);

            returnedUser.PasswordHash = null;

            return returnedUser;
        }

        public User Login(User user)
        {
            User loggedIn = _UserRepository.GetUserByUsername(user.Username);

            if (loggedIn == null || !loggedIn.PasswordHash.Equals(user.PasswordHash))
            {
                throw new ArgumentException("The Username and/or Password was not correct");
            }

            loggedIn.PasswordHash = null;

            return loggedIn;
        }

        public User Update(User user)
        {
            User userUpdated = _UserRepository.UpdateUser(user);
            userUpdated.PasswordHash = null;
            return userUpdated;
        }
    }
}
