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

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentPutPostDto newComment)
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
    }
}
