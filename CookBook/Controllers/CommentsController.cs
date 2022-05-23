using AutoMapper;
using CookBook.Application.Commands.CommentCommands;
using CookBook.Application.Queries.CommentQueries;
using CookBook.Domain.Models;
using CookBook.Dtos.CommentDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public CommentsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-comment-by-id/{id}")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            var query = new GetCommentById { CommentId = id };
            var comment = await _mediator.Send(query);

            if (comment == null)
                return NotFound();

            var foundComment = _mapper.Map<CommentGetDto>(comment);
            return Ok(foundComment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _mediator.Send(new GetAllComments());

            var foundComments = _mapper.Map<List<CommentGetDto>>(comments);
            return Ok(foundComments);
        }

        [HttpGet]
        [Route("get-all-comments-by-post-id/{id}")]
        public async Task<IActionResult> GetAllCommentsByPostId(Guid id)
        {
            var query = new GetAllCommentsByPostId
            {
                PostId = id
            };
            var comments = await _mediator.Send(query);

            var foundComments = _mapper.Map<List<CommentGetDto>>(comments);
            return Ok(foundComments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentPutPostDto newComment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateComment
            {
                PostId = newComment.PostId,
                Content = newComment.Content
            };

            var comment = _mapper.Map<CommentPutPostDto, Comment>(newComment);

            Comment createdComment = null;

            try
            {
                createdComment = await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return NotFound();
            }

            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, createdComment);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, [FromBody] CommentPutPostDto updatedComment)
        {
            var command = new UpdateComment
            {
                CommentId = id,
                PostId = updatedComment.PostId,
                Content = updatedComment.Content
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/{userId}/update-comment-content")]
        public async Task<IActionResult> UpdateCommentContent(Guid id, Guid userId, [FromBody] string newCommentContent)
        {
            var command = new UpdateCommentContent
            {
                CommentId = id,
                UserId = userId,
                NewContent = newCommentContent
            };

            Comment result = null;

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

        [HttpDelete]
        [Route("{id}/{userId}")]
        public async Task<IActionResult> DeleteComment(Guid id, Guid userId)
        {
            var command = new DeleteComment
            {
                CommentId = id,
                UserId = userId
            };

            var foundComment = await _mediator.Send(command);

            if (foundComment == null)
                return NotFound();

            return NoContent();
           
        }
    }
}
