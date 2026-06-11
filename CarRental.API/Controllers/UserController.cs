using CarRental.API.Extensions;
using CarRental.API.Models;
using CarRental.Application.DTOs;
using CarRental.Application.Interfaces;
using CarRental.Domain.Account;
using CarRental.Domain.Entities;
using CarRental.Domain.Pagination;
using CarRental.Infra.IoC;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUserService _userService;

        public UserController(IAuthenticate authenticateService, IUserService userService)
        {
            _authenticateService = authenticateService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<UserDTO>>> GetUsers([FromQuery]PaginationParams paginationParams)
        {
            int? userId = User.GetId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            UserDTO? user = await _userService.GetAsync(userId.Value);

            if (!user.IsAdmin)
            {
                return Unauthorized("Not enough permissions");
            }

            PagedList<UserDTO> userDTOs = await _userService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader
                (userDTOs.CurrentPage, userDTOs.PageSize, userDTOs.TotalCount, userDTOs.TotalPages));

            return Ok(userDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            int? userId = User.GetId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            UserDTO? user = await _userService.GetAsync(userId.Value);

            if (id == 0)
            {
                id = userId.Value;
            }

            if (!user.IsAdmin && user.Id != id)
            {
                return Unauthorized("Not enough permissions");
            }

            UserDTO? userDTO = await _userService.GetAsync(id);

            if (userDTO == null)
            {
                return NotFound("User not found");
            }

            return Ok(userDTO);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Create(UserLoginDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Invalid data");
            }

            bool emailExists = await _authenticateService.UserExistsAsync(userDTO.Email);

            if (emailExists)
            {
                return BadRequest("This e-mail is already registered");
            }

            bool registeredUserExists = await _userService.RegisteredUserExistsAsync();

            if (!registeredUserExists)
            {
                userDTO.IsAdmin = true;
            }

            UserLoginDTO user = await _userService.CreateAsync(userDTO);
            if (user == null)
            {
                return BadRequest("An error occurred while registering.");
            }

            string token = _authenticateService.GenerateToken(user.Id, user.Email);

            return new UserToken
            {
                Token = token,
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Select(LoginModel model)
        {
            bool userExists = await _authenticateService.UserExistsAsync(model.Email);

            if (!userExists)
            {
                return Unauthorized("User does not exists");
            }

            bool result = await _authenticateService.AuthenticateAsync(model.Email, model.Password);

            if (!result)
            {
                return Unauthorized("Wrong password");
            }

            User user = await _authenticateService.GetUserByEmailAsync(model.Email);

            string token = _authenticateService.GenerateToken(user.Id, user.Email);

            return new UserToken
            {
                Token = token,
                IsAdmin = user.IsAdmin,
                Email = user.Email
            };
        }

        [HttpPut]
        public async Task<ActionResult> Update(UserDTO userDTO)
        {
            int? userId = User.GetId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            UserDTO? user = await _userService.GetAsync(userId.Value);

            if (!user.IsAdmin && userDTO.Id != userId.Value)
            {
                return Unauthorized("Not enough permissions");
            }

            if (!user.IsAdmin && userDTO.Id == userId.Value && userDTO.IsAdmin)
            {
                return Unauthorized("Not enough permissions");
            }

            userDTO = await _userService.UpdateAsync(userDTO);

            if (userDTO == null)
            {
                return BadRequest("Error updating user");
            }

            return Ok("User updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(uint id)
        {
            int? userId = User.GetId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            UserDTO? user = await _userService.GetAsync(userId.Value);

            if (!user.IsAdmin)
            {
                return Unauthorized("Not enough permissions");
            }

            UserDTO? userDTO = await _userService.DeleteAsync(id);

            if (userDTO == null)
            {
                return BadRequest("Error deleting user");
            }

            return Ok("User deleted successfully");
        }
    }
}
