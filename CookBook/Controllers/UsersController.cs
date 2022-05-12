using AutoMapper;
using CookBook.Application.Commands.UserCommands;
using CookBook.Application.Queries.UserQueries;
using CookBook.Domain.Models;
using CookBook.Dtos.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public UsersController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserById { UserId = id };
            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound();

            var foundUser = _mapper.Map<UserGetDto>(user);
            return Ok(foundUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserPutPostDto newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateUser
            {
                UserName = newUser.UserName,
                Password = newUser.Password,
                Email = newUser.Email,
                PhoneNumber = newUser.PhoneNumber,
                CurrentOccupation = newUser.CurrentOccupation,
                Description = newUser.Description
            };

            var user = _mapper.Map<UserPutPostDto, User>(newUser);

            User createdUser = null;

            try
            {
                createdUser = await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return NotFound();
            }

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, createdUser);
        }

    }
}
