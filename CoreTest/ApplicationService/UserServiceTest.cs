using System.Collections.Generic;
using Moq;
using WebShop.Core.ApplicationService.Impl;
using WebShop.Core.DomainService;
using WebShop.Core.Entity;
using Xunit;

namespace CoreTest.ApplicationService
{
    public class UserServiceTest
    {
        private Mock<IUserRepository> _mockUserRepo = new Mock<IUserRepository>();

        public UserServiceTest()
        {
            _mockUserRepo.Setup(x => x.ReadUserById(It.IsAny<int>())).Returns(new Customer());
        }

        [Fact]
        public void CreateValidCustomerTest()
        {
            var userService = new UserService(_mockUserRepo.Object);
            var cust = new Customer()
            {
                Firstname = "Jens",
                Lastname = "Jensen",
                Email = "jens@jensen.dk",
                Username = "jens8677",
                Address = "jensengade 21",
                City = "Esbjerg",
                ZipCode = 6700
            };

            userService.CreateCustomer(cust);
            _mockUserRepo.Verify(x => x.Create(It.IsAny<Customer>()), Times.Once);
        }
        
        [Fact]
        public void CreateValidEmployeeTest()
        {
            var userService = new UserService(_mockUserRepo.Object);
            var employee = new Employee()
            {
                Firstname = "Jens",
                Lastname = "Jensen",
                Email = "jens@jensen.dk",
                Username = "jens8677",
                AccessLvl = 1
            };

            userService.CreateEmployee(employee);
            _mockUserRepo.Verify(x => x.Create(It.IsAny<Employee>()), Times.Once);
        }

        [Fact]
        public void GetValidUserById()
        {
            var usersService = new UserService(_mockUserRepo.Object);
            var user = usersService.GetUserById(1);
            Assert.NotNull(user);
        }

        [Fact]
        public void UpdateValidUser()
        {
            var usersService = new UserService(_mockUserRepo.Object);
            var user = new Customer();
            usersService.Update(user);
            _mockUserRepo.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void DeleteValidUser()
        {
            var usersService = new UserService(_mockUserRepo.Object);
            var user = new Customer();
            usersService.Delete(user);
            _mockUserRepo.Verify(x => x.Delete(It.IsAny<User>()), Times.Once);
        }
    }
}