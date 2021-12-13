using Moq;
using NUnit.Framework;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;
using Steer73.FormsApp.ViewModels;
using System;
using System.Threading.Tasks;

namespace Steer73.FormsApp.Tests.ViewModels
{
    [TestFixture]
    public class UsersViewModelTests
    {
        [Test]
        public async Task InitializeFetchesTheData()
        {
            //Arrange
            var userService = new Mock<IUserService>();
            var messageService = new Mock<IMessageService>();

            var viewModel = new UsersViewModel(
                userService.Object,
                messageService.Object);


            //Act
            userService
                .Setup(p => p.GetUsers())
                .ReturnsAsync(new[]
                {
                    new User { FirstName = "Milosz", LastName = "Skalecki" },
                    new User { FirstName = "Jon", LastName = "Bennett" },
                    new User { FirstName = "Alex", LastName = "Welding" },
                    new User { FirstName = "Nick", LastName = "Waites" },
                });

            await viewModel.Initialize();


            //Assert
            Assert.IsTrue(viewModel.Users.Count != 0);
        }

        [Test]
        public async Task InitializeShowErrorMessageOnFetchingError()
        {
            // Arrange
            var userService = new Mock<IUserService>();
            var messageService = new Mock<IMessageService>();

            var viewModel = new UsersViewModel(
                userService.Object,
                messageService.Object);

            //Act
            userService
                .Setup(p => p.GetUsers())
                .Throws(new Exception("Something went wrong"))
                .Verifiable();

            messageService
                .Setup(m => m.ShowError("Something went wrong"))
                .Returns(Task.CompletedTask)
                .Verifiable();

            //Assert
            await viewModel.Initialize();

            messageService.VerifyAll();
        }
    }
}
