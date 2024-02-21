using ForumSystem.Exceptions;
using ForumSystem.Responses;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Models.DTO;
using SmartGarage.Services;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserDataService _userDataService;

        public AuthController(IAccountService accountService, IUserDataService userDataService)
        {
            _accountService = accountService;
            _userDataService = userDataService;
        }

        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterUserDTO registerRequest)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }
            try
            {
                _accountService.RegisterUser(registerRequest);

                return Ok();
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }
        }


        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] LoginUserDTO loginRequest)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }

            try
            {
                var user = _accountService.LoginUser(loginRequest);

                if (user == null)
                {
                    return Unauthorized(new ErrorResponse("Invalid credentials."));
                }

                return Ok(new AuthenticatedUserResponse()
                {
                    accessToken = _accountService.GenerateToken(user)
                });

          
                
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }
            catch (Exception e)
            {
                // Handle unexpected exceptions here
                return StatusCode(500, new ErrorResponse("An unexpected error occurred."));
            }
        }
        [HttpPut("/user/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO userDto)
        {
            if (userDto == null || id != userDto.UserID)
            {
                return BadRequest();
            }

            try
            {
                var existingUser = _userDataService.GetUserById(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.FirstName = userDto.FirstName;
                existingUser.LastName = userDto.LastName;
                existingUser.phoneNumber = userDto.PhoneNumber;

                _userDataService.UpdateUser(existingUser);

                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
