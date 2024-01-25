using Microsoft.AspNetCore.Mvc;
using PopulateHtmlDataApi.Models.RequestViewModels;
using PopulateHtmlDataApi.Models.ResponseViewModels;
using PopulateHtmlDataApi.ResponseModels;
using PopulateHtmlDataApi.Services.Interfaces;

namespace PopulateHtmlDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[Action]{PolicyNumber}")]
        public async Task<ActionResult> GetUserByPolicyNumberAsync(string PolicyNumber)
        {
            APIResponse response = new();
            try
            {
                var result  = await _userService.GetUserByPolicyNumberAsync(PolicyNumber);
                response.Body = result;
                return Ok(response);
            }

            catch (Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "404";
                return Ok(response);
            }
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult> GetAllUsersAsync()
        {
            APIResponse response = new();
            try
            {
                IEnumerable<UserResponseModel> allUsers = (IEnumerable<UserResponseModel>)await _userService.GetAllUsersAsync();
                response.Body = allUsers;
                return Ok(response);
            }

            catch (Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "404";
                return Ok(response);
            }
        }

        [HttpPost("[Action]")]
        public async Task<ActionResult> AddUserAsync([FromBody] UserRequestModel user)
        {
            APIResponse response = new();
            try
            {
                var result = await _userService.AddUserAsync(user);
                return Ok("user added ");
            }

            catch (Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "401";
                return Ok(response);
            }
        }

        [HttpDelete("[Action]{PolicyNumber}")]
        public async Task<ActionResult> DeleteUserAsync(string PolicyNumber)
        {
            APIResponse response = new();
            try
            {
                var result = await _userService.DeleteUserAsync(PolicyNumber);
                return Ok("file deleted");
            }

            catch (Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "404";
                return Ok(response);
            }
        }

        [HttpPut("[Action]")]
        public async Task<ActionResult> UpdateUserAsync(UserRequestModel user)
        {
            APIResponse response = new();
            try
            {
                var result = await _userService.UpdateUserAsync(user);
                return Ok("file updated");
            }

            catch (Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "404";
                return Ok(response);
            }
        }

    }
}
