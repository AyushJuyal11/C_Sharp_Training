using NotificationAPI.Models.RequestViewModels;
using NotificationAPI.ResponseModels;
using NotificationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NotificationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IHttpService _httpService;

        public UserController(IUserService userService, IServiceProvider serviceProvider)
        {
            _userService = userService;
            _httpService = serviceProvider.GetRequiredService<IHttpService>();
        }


        [HttpPost("[Action]")]
        public async Task<IActionResult> AddUserAsync([FromBody]UserRequestModel user)
        {
            APIResponse response = new();
            try
            {
                var result = await _userService.AddUserAsync(user);
                var microserviceResult = _httpService.SendUserData(user); 
                response.Body = result;
                return Ok(response + "Policy created");
            }

            catch (Exception e) 
            {
                response.Errors = e.ToString(); 
                response.Message = e.Message;
                response.Code = "401"; 
                return Ok(response);
            }

        }
    }
}
