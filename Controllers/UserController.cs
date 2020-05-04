using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Full_Stack_Food_Truck_Application.Helpers;
using Full_Stack_Food_Truck_Application.Models.UserModels;
using Full_Stack_Food_Truck_Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Full_Stack_Food_Truck_Application.Controllers
{
    [Authorize]
    public class UserController : APIController
    {
        private readonly IUserServices _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(
                   IUserServices userService,
                   IMapper mapper,
                   IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateUserModel model) {
            var userToAuthenticate = _userService.Authenticate(model.Email, model.Password);
            if (userToAuthenticate == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userToAuthenticate.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                userToAuthenticate.Id,
                userToAuthenticate.Email,
                userToAuthenticate.First_Name,
                userToAuthenticate.Last_Name,
                Token = tokenString
            });
        }
    }
}
