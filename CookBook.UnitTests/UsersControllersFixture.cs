using AutoMapper;
using CookBook.Application.Commands.UserCommands;
using CookBook.Application.Queries.UserQueries;
using CookBook.Controllers;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.UnitTests
{
    [TestClass]
    public class UsersControllersFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Users_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllUsers>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new UsersController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllUsers();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllUsers>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
