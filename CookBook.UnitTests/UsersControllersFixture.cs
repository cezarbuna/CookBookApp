using AutoMapper;
using CookBook.Application.Commands.UserCommands;
using CookBook.Application.Queries.UserQueries;
using CookBook.Controllers;
using CookBook.Dtos.UserDtos;
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

        [TestMethod]
        public async Task Get_User_By_Id_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserById>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test id
            var testId = Guid.NewGuid();

            //Act
            var controller = new UsersController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetUserById(testId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetUserById>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_User_Id_By_Username_query_is_called()
        { 
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserIdByUsername>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test id
            var testUsername = "random username";

            //Act
            var controller = new UsersController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetUserIdByUsername(testUsername);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetUserIdByUsername>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Update_User_command_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateUser>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomId = Guid.NewGuid();
            var userDto = new UserPutPostDto
            {
                UserName = "random username",
                Password = "random password",
                Email = "random email",
                PhoneNumber = "073154321123",
                CurrentOccupation = "random occupation",
                Description = "random description"
            };



            //Act
            var controller = new UsersController(_mockMapper.Object, _mockMediator.Object);
            await controller.UpdateUser(randomId, userDto);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateUser>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        //[TestMethod]
        //public async Task Create_User_command_is_called()
        //{
        //    //Arrange
        //    _mockMediator
        //        .Setup(m => m.Send(It.IsAny<CreateUser>(), It.IsAny<CancellationToken>()))
        //        .Verifiable();

        //    var userDto = new UserPutPostDto
        //    {
        //        UserName = "random username",
        //        Password = "random password",
        //        Email = "random email",
        //        PhoneNumber = "073154321123",
        //        CurrentOccupation = "random occupation",
        //        Description = "random description"
        //    };



        //    //Act
        //    var controller = new UsersController(_mockMapper.Object, _mockMediator.Object);
        //    await controller.CreateUser( userDto);

        //    //Assert
        //    _mockMediator.Verify(x => x.Send(It.IsAny<CreateUser>(), It.IsAny<CancellationToken>()), Times.Once());
        //}


    }
}
