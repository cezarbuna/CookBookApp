using AutoMapper;
using CookBook.Application.Commands.PostCommands;
using CookBook.Application.Queries.PostQueries;
using CookBook.Application.Queries.UserQueries;
using CookBook.Controllers;
using CookBook.Dtos.PostDtos;
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
    public class PostsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Posts_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllPosts>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new PostsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllPosts();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllPosts>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Post_By_Id_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetPostById>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test id
            var testId = Guid.NewGuid();

            //Act
            var controller = new PostsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetPostById(testId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetPostById>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_All_Posts_By_User_Id_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllPostsByUserId>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test user ID
            var testUserId = Guid.NewGuid();

            //Act
            var controller = new PostsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllPostsByUserId(testUserId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllPostsByUserId>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_All_Posts_By_Category_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllPostsByCategory>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test id
            int testCategory = 1;

            //Act
            var controller = new PostsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllPostsByCategory(testCategory);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllPostsByCategory>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_All_Badly_Rated_Posts_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllBadlyRatedPosts>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new PostsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllBadlyRatedPosts();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllBadlyRatedPosts>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Update_Post_command_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdatePost>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //data for update
            var id = Guid.NewGuid();
            var postDto = new PostPutPostDto
            {
                UserId = Guid.NewGuid(),
                Title = "random title",
                Content = "random content",
                LikeCounter = 0,
                DislikeCunter = 0,
                Category = 1
            };

            //Act
            var controller = new PostsController(_mockMapper.Object, _mockMediator.Object);
            await controller.UpdatePost(id, postDto);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<UpdatePost>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Delete_Post_command_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeletePost>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //random test post ID
            var postId = Guid.NewGuid();

            //Act
            var controller = new PostsController(_mockMapper.Object, _mockMediator.Object);
            await controller.DeletePost(postId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<DeletePost>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }

    
}
