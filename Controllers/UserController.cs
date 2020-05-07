using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IFavoriteService _favService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(
                   IUserServices userService,
                   IFavoriteService favService,
                   IMapper mapper,
                   IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _favService = favService;
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
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
        //get all users
        [HttpGet("")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAll();
                var returnObject = _mapper.Map<List<GetUserModel>>(users);
                return Ok(returnObject);
            }
            catch(AppException ex)
            { return BadRequest(new { message = ex.Message }); }

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
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
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
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
        [HttpPost("Delete/{Id}")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            try
            {
                var user = _userService.GetById(Id);
                var favIdList = new List<string>();
                foreach (Favorite favorite in user.Favorites) {
                    favIdList.Add(favorite.Id);
                }
                await _favService.DeleteListOfFavorites(favIdList);
                _userService.Delete(Id);
                return Ok("User has successfully been deleted");
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
    }
}
