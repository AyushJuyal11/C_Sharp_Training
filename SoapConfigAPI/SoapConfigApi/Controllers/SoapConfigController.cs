﻿using Microsoft.AspNetCore.Mvc;
using Serilog;
using SoapConfigAPI.Models.RequestViewModels;
using SoapConfigAPI.Models.ResponseViewModels;
using SoapConfigAPI.ResponseModels;
using SoapConfigAPI.Services.Interfaces;

namespace SoapConfigAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoapConfigController : ControllerBase
    {

        private readonly ISoapConfigService _soapConfigService; 
        
        public SoapConfigController(ISoapConfigService soapConfigService)
        {
            _soapConfigService = soapConfigService; 
        }

        [HttpGet("[Action]{ID:int}")]
        public async Task<ActionResult> GetSoapConfigByIdAsync(int ID)
        {
            APIResponse response = new();
            try
            {
                List<UserResponseModel> userResponseModels = (List<UserResponseModel>)await _soapConfigService.GetSoapConfigByIdAsync(ID);
                response.Body = userResponseModels;
                Log.Information(response.ToString()); 
                return Ok(response);
            }

            catch (Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "404";
                Log.Information(response.ToString()); 
                return Ok(response); 
            }
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult> GetAllSoapConfigsAsync()
        {
            APIResponse response = new(); 
            try
            {
                List<UserResponseModelList> allUsers = (List<UserResponseModelList>)await _soapConfigService.GetAllSoapConfigsAsync();
                response.Body = allUsers;
                Log.Information($"{response.ToString()}"); 
                return Ok(response); 
            }

            catch (Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "404";
                Log.Information($"{response.ToString()}");
                return Ok(response); 
            }
        }

        [HttpPost("[Action]")]
        public async Task<ActionResult> AddSoapConfigAsync([FromBody]SoapConfigRequest soapConfig)
        {
            APIResponse response = new();
            try
            {
                var result = await _soapConfigService.AddSoapConfigAsync(soapConfig);
                Log.Information($"{response.ToString()}");
                return Ok("file added "); 
            }

            catch (Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "401";
                Log.Information($"{response.ToString()}"); 
                return Ok(response); 
            }
        }

        [HttpDelete("[Action]{ID:int}")]
        public async Task<ActionResult> DeleteSoapConfigAsync(int ID)
        {
            APIResponse response = new();
            try
            {
                var result = await _soapConfigService.DeleteSoapConfigAsync(ID);
                Log.Information($"{response.ToString()}"); 
                return Ok("file deleted"); 
            }

            catch(Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "404";
                Log.Information($"{response.ToString()}"); 
                return Ok(response); 
            }
        }

        [HttpPut("[Action]")]
        public async Task<ActionResult> UpdateSoapConfigAsync(SoapConfigRequest soapConfig)
        {
            APIResponse response = new();
            try
            {
                var result = await _soapConfigService.UpdateSoapConfigAsync(soapConfig) ;
                Log.Information($"{response.ToString()}"); 
                return Ok("file updated"); 
            }
            
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "404"; 
                Log.Information($"{response.ToString()}"); 
                return Ok(response);
            }
        }
    }
}
