using ForumSystem.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Services.Contracts;
using SmartGarage.Models.DTO;
using ForumSystem.Exceptions;

namespace SmartGarage.Controllers.API
{
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public LoginUserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] UserLoginDTO loginRequest)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }
            try
            {
                var loginResult = _accountService.LoginUser(loginRequest);
                if (loginResult == null)
                {
                    return Unauthorized(new ErrorResponse("Invalid credentials."));
                }               
                return Ok();
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }
        }
    }
}
