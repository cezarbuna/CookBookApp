using AutoMapper;
using CookBook.Application.Commands.PostCommands;
using CookBook.Application.Queries.PostQueries;
using CookBook.Domain.Models;
using CookBook.Dtos.PostDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public PostsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-post-by-id/{id}")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            var query = new GetPostById { PostId = id };
            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound();

            var foundPost = _mapper.Map<PostGetDto>(user);
            return Ok(foundPost);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _mediator.Send(new GetAllPosts());

            var foundPosts = _mapper.Map<List<PostGetDto>>(posts);
            return Ok(foundPosts);
        }

        [HttpGet]
        [Route("get-all-posts-by-user-id/{id}")]
        public async Task<IActionResult> GetAllPostsByUserId(Guid id)
        {
            var query = new GetAllPostsByUserId
            {
                UserId = id
            };
            var posts = await _mediator.Send(query);

            var foundPosts = _mapper.Map<List<PostGetDto>>(posts);
            return Ok(foundPosts);
        }

        [HttpGet]
        [Route("get-all-posts-by-category/{category}")]
        public async Task<IActionResult> GetAllPostsByCategory(int category)
        {
            var query = new GetAllPostsByCategory
            {
                Category = category
            };
            var posts = await _mediator.Send(query);

            var foundPosts = _mapper.Map<List<PostGetDto>>(posts);
            return Ok(foundPosts);
        }

        [HttpGet]
        [Route("get-all-badly-rated-posts")]
        public async Task<IActionResult> GetAllBadlyRatedPosts()
        {
            var query = new GetAllBadlyRatedPosts();

            var posts = await _mediator.Send(query);

            var foundPosts = _mapper.Map<List<PostGetDto>>(posts);
            return Ok(foundPosts);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostPutPostDto newPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreatePost
            {
                UserId = newPost.UserId,
                Content = newPost.Content,
                LikeCounter = newPost.LikeCounter,
                DislikeCunter = newPost.DislikeCunter,
                Category = newPost.Category
            };

            var post = _mapper.Map<PostPutPostDto, Post>(newPost);

            Post createdPost = null;

            try
            {
                createdPost = await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return NotFound();
            }

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, createdPost);
        }

        [HttpPatch]
        [Route("{id}/{userId}/update-post-content/{newPostContent}")]
        public async Task<IActionResult> UpdatePostContent(Guid id, Guid userId, string newPostContent)
        {
            var command = new UpdatePostContent
            {
                PostId = id,
                UserId = userId,
                NewPostContent = newPostContent
            };

            Post result = null;

            try
            {
                result = await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return NotFound();
            }

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/{userId}/update-post-category/{newPostCategory}")]
        public async Task<IActionResult> UpdatePostCategory(Guid id, Guid userId, int newPostCategory)
        {
            var command = new UpdatePostCategory
            {
                PostId = id,
                UserId = userId,
                NewCategory = newPostCategory
            };

            Post result = null;

            try
            {
                result = await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return NotFound();
            }

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("like-post/{id}")]
        public async Task<IActionResult> LikePost(Guid id)
        {
            var command = new LikePost
            {
                PostId = id
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("dislike-post/{id}")]
        public async Task<IActionResult> DislikePost(Guid id)
        {
            var command = new DislikePost
            {
                PostId = id
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var command = new DeletePost { PostId = id };
            var foundPost = await _mediator.Send(command);

            if (foundPost == null) return NotFound();

            return NoContent();
        }
    }
}
