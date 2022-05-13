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
        [Route("{id}/update-post-content/{newPostContent}")]
        public async Task<IActionResult> UpdatePostContent(Guid id, string newPostContent)
        {
            var command = new UpdatePostContent
            {
                PostId = id,
                NewPostContent = newPostContent
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/update-post-category/{newPostCategory}")]
        public async Task<IActionResult> UpdatePostCategory(Guid id, int newPostCategory)
        {
            var command = new UpdatePostCategory
            {
                PostId = id,
                NewCategory = newPostCategory
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
