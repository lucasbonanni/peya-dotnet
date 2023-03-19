using AutoMapper;
using core;
using Moq;
using NUnit.Framework;
using Services;
using System;
using TaskAPI.Automapper;
using TaskAPI.Controllers;
using TaskAPI.Dto;

namespace TaskAPI.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<IUserService> mockUserService;
        private IMapper mapper;



        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add your mapper profile configs here
                cfg.AddProfile<MappingProfile>();
            });

            this.mockUserService = new Mock<IUserService>();
            this.mapper = config.CreateMapper();


        }

        private UserController CreateUserController()
        {
            return new UserController(this.mapper, mockUserService.Object);
        }

        [Test]
        public void Get_AllUsers_ReturnTwoUsers()
        {
            // Arrange
            var userController = this.CreateUserController();
            var expected = new List<User>() { new User(), new User() };
            this.mockUserService.Setup(x => x.GetAll()).Returns(expected);

            // Act
            var result = userController.Get();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Get_S the get by id_ return expected user.
        /// </summary>
        [Test]
        public void Get_GetById_ReturnExpectedUser()
        {
            // Arrange
            var userController = this.CreateUserController();
            Guid id = Guid.NewGuid();
            User expected = new User() { Id = id, Name = "Pedro" };
            this.mockUserService.Setup(x => x.Get(id)).Returns(expected);

            // Act
            var result = userController.Get(id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(expected.Name));
            Assert.That(result.Id, Is.EqualTo(expected.Id));
            this.mockUserService.VerifyAll();
        }

        [Test]
        public void Post_CreateNewUser_ReturnTheCreatedUser()
        {
            // Arrange
            var userController = this.CreateUserController();
            UserDto value = null;

            // Act
            userController.Post(
                value);

            // Assert
            Assert.Fail();
            this.mockUserService.VerifyAll();
        }

        [Test]
        public void Put_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userController = this.CreateUserController();
            Guid id = Guid.NewGuid();
            UserDto value = null;

            // Act
            userController.Put(
                id,
                value);

            // Assert
            Assert.Fail();
            this.mockUserService.VerifyAll();
        }

        /// <summary>
        /// Test the Delete method when an id is passed and the service calls the delete method.
        /// </summary>
        [Test]
        public void Delete_AnIdIsPassed_TheServiceDeleteMethodIsCalled()
        {
            // Arrange
            var userController = this.CreateUserController();
            mockUserService.Setup(x => x.Delete(It.IsAny<Guid>())).Verifiable();
            Guid id = Guid.NewGuid();

            // Act
            userController.Delete(id);

            // Assert
            this.mockUserService.VerifyAll();
        }
    }
}
