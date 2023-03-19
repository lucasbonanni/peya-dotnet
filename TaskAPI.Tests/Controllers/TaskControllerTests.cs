using Moq;
using NUnit.Framework;
using System;
using TaskAPI.Controllers;

namespace TaskAPI.Tests.Controllers
{
    [TestFixture]
    public class TaskControllerTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private TaskController CreateTaskController()
        {
            return new TaskController();
        }

        [Test]
        public void Get_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskController = this.CreateTaskController();

            // Act
            var result = taskController.Get();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Get_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var taskController = this.CreateTaskController();
            int id = 0;

            // Act
            var result = taskController.Get(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Post_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskController = this.CreateTaskController();
            string value = null;

            // Act
            taskController.Post(
                value);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Put_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskController = this.CreateTaskController();
            int id = 0;
            string value = null;

            // Act
            taskController.Put(
                id,
                value);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskController = this.CreateTaskController();
            int id = 0;

            // Act
            taskController.Delete(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
