using ForumSystem.Exceptions;
using ForumSystem.Responses;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
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

                return Ok(new AuthenticatedUserResponse()
                {
                    accessToken = _accountService.GenerateToken(user)
                }); ;
            }
            catch (Exception e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }
        }
    }
}
