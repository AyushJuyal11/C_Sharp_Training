using Microsoft.AspNetCore.Mvc;
using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.Models.RequestViewModels;
using PopulateHtmlDataApi.Models.ResponseViewModels;
using PopulateHtmlDataApi.ResponseModels;
using PopulateHtmlDataApi.Services.Interfaces;

namespace PopulateHtmlDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DocumentGenerationController : ControllerBase
    {
        private readonly IEPolicyKitDocumentGenerationService _documentGenerationService;
        private readonly IAddDocumentService _documentAddService;
        private readonly IHtmlTemplateService _htmlTemplateService; 
        private readonly IUserService _userService;  

        public DocumentGenerationController(IAddDocumentService documentAddService , IEPolicyKitDocumentGenerationService documentGenerationService , IUserService userService , IHtmlTemplateService htmlTemplateService)
        {
            _documentAddService=documentAddService;
            _documentGenerationService = documentGenerationService;
            _userService = userService; 
            _htmlTemplateService = htmlTemplateService;
        }

        [HttpPost("[Action]")]
        public async Task<ActionResult> GenerateDocumentAsync([FromBody]DocumentCreationUserRequestModel userRequestModel)
        {
            APIResponse response = new();
            try
            {
                HtmlTemplateResponseModel htmlTemplateResponseModel = await _htmlTemplateService.GetHtmlTemplateByIdAsync(4);
                UserResponseModel userResponseModel = await _userService.GetUserByPolicyNumberAsync(userRequestModel.PolicyNumber);
                DocumentEntity document = await _documentGenerationService.GenerateDocumentAsync(userResponseModel, htmlTemplateResponseModel.Content);
                int result = await _documentAddService.AddDocumentAsync(document); 
                return Ok($"Document created for user with Policy Number : {userResponseModel.PolicyNumber}"); 
            }
            catch(Exception e)
            {
                response.Message = e.Message;
                response.Errors = e.ToString();
                response.Code = "401";
                return Ok(response);
            }
        }

    }
}
