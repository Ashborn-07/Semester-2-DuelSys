using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using Xunit;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void RegisterValidUser()
        {
            // Arrange  
            User user = new User(1, "username", "1234", "Peca", "Todorov", 21, Gender.MALE, "peca@gmail.com", new WinRate(0, 0));

            UserMock userMock = new UserMock();
            IUserRepository repository = userMock;
            UserService service = new UserService(repository);

            // Act
            service.RegisterUser(user);

            // Assert
            List<User> users = userMock.GetUsers();
            Assert.AreEqual(user.UserName, users[1].UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException), "Username exception not found")]
        public void RegisterUserGetExceptionUsernameTaken()
        {
            // Arrange
            User user = new User(1, "test1", "1234", "Lili", "Todorova", 21, Gender.FEMALE, "asd@gmail.com", new WinRate(0, 0));

            UserMock userMock = new UserMock();
            IUserRepository repository = userMock;
            UserService service = new UserService(repository);

            // Act
            service.RegisterUser(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException), "Email exception not found")]
        public void RegisterUserGetExceptionEmailTaken()
        {
            // Arrange
            User user = new User(1, "username", "1234", "Peca", "Todorov", 21, Gender.MALE, "lili@gmail.com", new WinRate(0, 0));

            UserMock userMock = new UserMock();
            IUserRepository repository = userMock;
            UserService service = new UserService(repository);

            // Act
            service.RegisterUser(user);
        }

        [TestMethod]
        public void LoggInUserSuccessfully()
        {
            // Arrange
            string username = "test1";
            string password = "password";

            UserMock userMock = new UserMock();
            IUserRepository repository = userMock;
            UserService service = new UserService(repository);

            // Act
            User user = service.CheckUserCredentials(username, password);

            // Assert
            Assert.AreEqual(username, user.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException), "Username or password should be invalid?")]
        public void ExceptionLoggInWrongUsernamePassword()
        {
            // Arrange
            string username = "test2";
            string password = "passwo";

            UserMock userMock = new UserMock();
            IUserRepository repository = userMock;
            UserService service = new UserService(repository);

            // Act
            service.CheckUserCredentials(username, password);
        }
    }
}