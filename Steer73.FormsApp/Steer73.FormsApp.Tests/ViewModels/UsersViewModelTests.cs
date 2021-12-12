using Moq;
using NUnit.Framework;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;
using Steer73.FormsApp.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Steer73.FormsApp.Tests.ViewModels
{
    [TestFixture]
    public class UsersViewModelTests
    {
        [Test]
        public async Task InitializeFetchesTheData()
        {
            var userService = new Mock<IUserService>();
            var messageService = new Mock<IMessageService>();

            var viewModel = new UsersViewModel(
                userService.Object,
                messageService.Object);

            userService
                .Setup(p => p.GetUsers())
                .Returns(Task.FromResult(Enumerable.Empty<User>()))
                .Verifiable();

            await viewModel.Initialize();

            userService.VerifyAll();
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
