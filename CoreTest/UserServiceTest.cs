using System;
using Moq;
using WebShop.Core;
using WebShop.Core.ApplicationService;
using WebShop.Core.ApplicationService.Impl;
using WebShop.Core.DomainService;
using WebShop.Core.Entity;
using Xunit;


namespace CoreTest
{
    public class UserServiceTest
    {

        [Fact]
        public void LoginWithValidUsernameAndPassword(){
            //Setup
            Mock<IUserRepository> mockRepo = new Mock<IUserRepository>();

            var testStringForHash = "qwertyuiopasdfghjk1234567890";
            var testUsername = "MyName";

            mockRepo.Setup(x => x.GetUserByUsername(It.IsAny<string>())).Returns(() => new User() { PasswordHash = testStringForHash });

            IUserService userService = new UserService(mockRepo.Object);

            //Test

            var returndUser = userService.Login(new User() { Username = testUsername, PasswordHash = testStringForHash });

            Assert.NotNull(returndUser);
        }

        [Fact]
        public void LoginWithNonValidPassword(){
            //Setup
            Mock<IUserRepository> mockRepo = new Mock<IUserRepository>();

            var testStringForHash = "qwertyuiopasdfghjk1234567890";
            var closeButNotQuite = "qwertyuiopasdfghjk123456789";
            var testUsername = "MyName";

            mockRepo.Setup(x => x.GetUserByUsername(It.IsAny<string>())).Returns(() => new User() { PasswordHash = testStringForHash });

            IUserService userService = new UserService(mockRepo.Object);

            //Test
            User returndUser = null;

            Assert.Throws<ArgumentException>(() => returndUser = userService.Login(new User() { Username = testUsername, PasswordHash = closeButNotQuite }));

            Assert.Null(returndUser);
        }


    }
}
