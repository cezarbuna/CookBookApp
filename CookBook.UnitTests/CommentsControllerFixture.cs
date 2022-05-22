using AutoMapper;
using CookBook.Application.Commands.CommentCommands;
using CookBook.Application.Queries.CommentQueries;
using CookBook.Application.Queries.PostQueries;
using CookBook.Controllers;
using CookBook.Dtos.CommentDtos;
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
    public class CommentsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Comments_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllComments>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new CommentsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllComments();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllComments>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_All_Comments_By_Id_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllCommentsByPostId>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test post Id
            var postId = Guid.NewGuid();

            //Act
            var controller = new CommentsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllCommentsByPostId(postId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllCommentsByPostId>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Comment_By_Id_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCommentById>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test comment Id
            var id = Guid.NewGuid();

            //Act
            var controller = new CommentsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetCommentById(id);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetCommentById>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Update_Comment_command_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateComment>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test comment Id
            var id = Guid.NewGuid();
            var commentDto = new CommentPutPostDto
            {
                PostId = Guid.NewGuid(),
                Content = "random test content"
            };

            //Act
            var controller = new CommentsController(_mockMapper.Object, _mockMediator.Object);
            await controller.UpdateComment(id, commentDto);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateComment>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Delete_Comment_command_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteComment>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test comment ID
            var commentId = Guid.NewGuid();
            var userID = Guid.NewGuid();

            //Act
            var controller = new CommentsController(_mockMapper.Object, _mockMediator.Object);
            await controller.DeleteComment(commentId, userID);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<DeleteComment>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
