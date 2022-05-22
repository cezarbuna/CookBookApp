using AutoMapper;
using CookBook.Application.Commands.AdminCommands;
using CookBook.Application.Queries.AdminQueries;
using CookBook.Controllers;
using CookBook.Dtos.AdminDtos;
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
    public class AdminsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Admins_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllAdmins>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new AdminsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllAdmins();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllAdmins>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Admin_By_Id_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAdminById>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test admin ID
            var adminId = Guid.NewGuid();

            //Act
            var controller = new AdminsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAdminById(adminId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAdminById>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Admin_Id_By_Id_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAdminIdById>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test ID
            var id = Guid.NewGuid();

            //Act
            var controller = new AdminsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAdminIdById(id);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAdminIdById>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Update_Admin_command_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateAdmin>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test ID
            var id = Guid.NewGuid();
            var adminDto = new AdminPutPostDto
            {
                UserName = "random username",
                Password = "random password"
            };

            //Act
            var controller = new AdminsController(_mockMapper.Object, _mockMediator.Object);
            await controller.UpdateAdmin(id, adminDto);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateAdmin>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
