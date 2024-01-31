using PolicyMailSendingAPI.Models.RequestViewModels;
using PolicyMailSendingAPI.ResponseModels;
using PolicyMailSendingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PolicyMailSendingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IDocumentGenerationService _documentGenerationService;

        public UserController(IUserService userService, IDocumentGenerationService documentGenerationService)
        {
            _userService = userService;
            _documentGenerationService=documentGenerationService;
        }


        [HttpPost("[Action]")]
        public async Task<IActionResult> AddUserAsync([FromBody]UserRequestModel user)
        {
            APIResponse response = new();
            try
            {
                var result = await _userService.AddUserAsync(user);
                var microserviceResult = _documentGenerationService.SendUserData(user); 
                response.Body = result;
                return Ok($"User with {user.PolicyNumber} created"); 
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
