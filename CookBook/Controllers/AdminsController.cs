using AutoMapper;
using CookBook.Application.Commands.AdminCommands;
using CookBook.Application.Queries.AdminQueries;
using CookBook.Domain.Models;
using CookBook.Dtos.AdminDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public AdminsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-admin-by-id/{id}")]
        public async Task<IActionResult> GetAdminById(Guid id)
        {
            var query = new GetAdminById { AdminId = id };
            var admin = await _mediator.Send(query);

            if (admin == null)
                return NotFound();

            var foundUser = _mapper.Map<AdminGetDto>(admin);
            return Ok(foundUser);
        }

        [HttpGet]
        [Route("get-admin-id-by-normal-id/{normalId}")]
        public async Task<IActionResult> GetAdminIdById(Guid normalId)
        {
            var query = new GetAdminIdById
            {
                NormalId = normalId
            };

            var adminId = await _mediator.Send(query);

            if (adminId == Guid.Empty)
                return NoContent();

            return Ok(adminId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _mediator.Send(new GetAllAdmins());

            var foundAdmins = _mapper.Map<List<AdminGetDto>>(admins);
            return Ok(foundAdmins);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(AdminPutPostDto newAdmin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateAdmin
            {
                UserName = newAdmin.UserName,
                Password = newAdmin.Password
            };

            var admin = _mapper.Map<AdminPutPostDto, Admin>(newAdmin);

            Admin createdAdmin = null;

            try
            {
                createdAdmin = await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return NotFound();
            }

            return CreatedAtAction(nameof(GetAdminById), new { id = admin.Id }, createdAdmin);
        }

        [HttpPatch]
        [Route("adminId")]
        public async Task<IActionResult> UpdateAdmin(Guid adminId, [FromBody] AdminPutPostDto updatedAdmin)
        {
            var command = new UpdateAdmin
            {
                AdminId = adminId,
                UserName = updatedAdmin.UserName,
                Password = updatedAdmin.Password
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }
    }
}
