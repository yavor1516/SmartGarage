using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Services.Contracts;
using System.Security.Claims;

namespace SmartGarage.Controllers.API
{
    [ApiController]
    [Authorize]
    [Route("/adminPanel")]
    public class AdminPanelController : ControllerBase
    {
        private readonly IAdminPanelDataService _adminPanelService;

        public AdminPanelController(IAdminPanelDataService adminPanelService)
        {
            _adminPanelService = adminPanelService;
        }

        [Authorize]

        [HttpPut("block/{username}")]
        public IActionResult BlockUser(string username)
        {

            try
            {
                var user = User.FindFirst(ClaimTypes.Name)?.Value;
                var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

                if (user != null && userRole == "True")
                {
                    var userToBlock = _adminPanelService.BlockUser(username);

                    return Ok();

                }
                return Unauthorized();


            }
            catch (Exception e)
            {
                return Conflict(new Exception("user doesnt exist!!"));
            }
        }
        [HttpPut("unblock/{username}")]
        public IActionResult UnBlockUser(string username)
        {

            try
            {
                var user = User.FindFirst(ClaimTypes.Name)?.Value;
                var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

                if (user != null && userRole == "True")
                {
                    var userToBlock = _adminPanelService.UnBlockUser(username);

                    return Ok();

                }
                return Unauthorized();


            }
            catch (Exception e)
            {
                return Conflict(new Exception("user doenst exist!!"));
            }
        }

    }
}
