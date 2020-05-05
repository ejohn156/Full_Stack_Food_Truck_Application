using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Full_Stack_Food_Truck_Application.Data.Entities;
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
        public IActionResult Authenticate([FromBody]AuthenticateUserModel model)
        {
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
        [AllowAnonymous]
        [HttpPost("Signup")]
        public IActionResult Signup([FromBody] CreateUserModel model)
        {
            try
            {
                var newUser = _mapper.Map<User>(model);
                return Ok(_userService.Create(newUser, model.password));
            }
            catch
            {
                return BadRequest("Unable to create user, user either exists or credentials are invalid");
            }
        }
        //get all users
        [HttpGet("")]
        public IActionResult GetAllUsers()
        {
            Console.WriteLine("getAllUsers has been called");
            try
            {
                var users = _userService.GetAll();
                Console.WriteLine(users); 
                Console.WriteLine(_mapper.Map<List<GetUserModel>>(users));
                var returnObject = _mapper.Map<List<GetUserModel>>(users);
                Console.WriteLine(returnObject);
                return Ok(returnObject);
            }
            catch
            { return BadRequest("Invalid request"); }

        }
        //get individual user
        [HttpGet("{Id}")]
        public IActionResult GetUser(string Id)
        {
            try
            {
                var user = _userService.GetById(Id);
                var returnObject = _mapper.Map<GetUserModel>(user);
                return Ok(returnObject);
            }
            catch
            {
                return BadRequest("Invalid request");
            }
        }
        //update user
        [HttpPut("{Id}")]
        public IActionResult UpdateUser(string Id, [FromBody]UpdateUserModel model)
        {
            try
            {
                var userToUpdate = _mapper.Map<User>(model);
                userToUpdate.Id = Id;
                _userService.Update(userToUpdate, model.Password);
                return Ok("User has been Updated successfully");
            }
            catch
            {
                return BadRequest("Update has failed due to invalid request or incorrect credentials");
            }
        }
        [HttpPost("Delete/{Id}")]
        public IActionResult DeleteUser(string Id)
        {
            try
            {
                _userService.Delete(Id);
                return Ok("User has successfully been deleted");
            }
            catch
            {
                return BadRequest("Invalid request");
            }
        }
    }
}
