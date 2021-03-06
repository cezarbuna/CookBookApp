using AutoMapper;
using CookBook.Application.Commands.UserCommands;
using CookBook.Application.Queries.AdminQueries;
using CookBook.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CookBook.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public AuthController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel inputUser)
        {

            var query = new LoginUser
            {
                UserName = inputUser.UserName,
                Password = inputUser.Password
            };

            var isLoggedIn = await _mediator.Send(query);

            if (!isLoggedIn)
                return NotFound();
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@346"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(

                    issuer: "http://localhost:4200/",
                    audience: "http://localhost:4200/",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signingCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }

        }

        [HttpPost, Route("login-admin")]
        public async Task<IActionResult> LoginAdmin([FromBody] AdminLoginModel inputAdmin)
        {

            var query = new LoginAdmin
            {
                AdminId = inputAdmin.AdminId,
                UserName = inputAdmin.UserName,
                Password = inputAdmin.Password
            };

            var isLoggedIn = await _mediator.Send(query);

            if (!isLoggedIn)
                return NotFound();
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@346"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:4200/",
                    audience: "http://localhost:4200/",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signingCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }

        }

        //[HttpPost, Route("login-admin")]
        //public async Task<IActionResult> LoginAdmin([FromBody] Admin inputAdmin)
        //{
        //    var query = new LoginAdmin
        //    {
        //        UserName = inputAdmin.UserName,
        //        Password = inputAdmin.Password,
        //        AdminId = inputAdmin.AdminId
        //    };

        //    var admin = await _mediator.Send(query);

        //    if (admin == null)
        //        return NotFound();
        //    else
        //    {
        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
        //        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        //        var tokenOptions = new JwtSecurityToken(
        //            issuer: "http://localhost:4200/",
        //            audience: "http://localhost:4200/",
        //            claims: new List<Claim>(),
        //            expires: DateTime.Now.AddMinutes(10),
        //            signingCredentials: signingCredentials
        //            );

        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //        return Ok(new { Token = tokenString });
        //    }

        //}
    }
}
