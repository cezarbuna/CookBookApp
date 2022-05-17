using AutoMapper;
using CookBook.Application.Commands;
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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsers());

            var foundUsers = _mapper.Map<List<UserGetDto>>(users);
            return Ok(foundUsers);
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

        [HttpPatch]
        [Route("{id}/update-user-username/{newUsername}")]
        public async Task<IActionResult> UpdateUserUsername(Guid id, string newUsername)
        {
            var command = new UpdateUserUsername
            {
                UserId = id,
                NewUserUsername = newUsername
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }
        
        [HttpPatch]
        [Route("{id}/update-user-password/{newPassword}")]
        public async Task<IActionResult> UpdateUserPassword(Guid id, string newPassword)
        {
            var command = new UpdateUserPassword
            {
                UserId = id,
                NewUserPassword = newPassword
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/update-user-email/{newEmail}")]
        public async Task<IActionResult> UpdateUserEmail(Guid id, string newEmail)
        {
            var command = new UpdateUserEmail
            {
                UserId = id,
                NewUserEmail = newEmail
            };

            var result = await _mediator.Send(command);

            if(result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/update-user-phoneNumber/{newPhoneNumber}")]
        public async Task<IActionResult> UpdateUserPhoneNumber(Guid id, string newPhoneNumber)
        {
            var command = new UpdateUserPhoneNumber
            {
                UserId = id,
                NewUserPhoneNumber = newPhoneNumber
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/update-user-currentOccupation/{newOccupation}")]
        public async Task<IActionResult> UpdateUserCurrentOccupation(Guid id, string newOccupation)
        {
            var command = new UpdateUserCurrentOccupation
            {
                UserId = id,
                NewUserOccupation = newOccupation
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}/update-user-description/{newDescription}")]
        public async Task<IActionResult> UpdateUserDescription(Guid id, string newDescription)
        {
            var command = new UpdateUserDescription
            {
                UserId = id,
                NewUserDescription = newDescription
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

    }
}
