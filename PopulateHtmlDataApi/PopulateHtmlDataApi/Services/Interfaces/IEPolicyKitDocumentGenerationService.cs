using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.Models.ResponseViewModels;

namespace PopulateHtmlDataApi.Services.Interfaces
{
    public interface IEPolicyKitDocumentGenerationService
    {
        public Task<DocumentEntity> GenerateDocumentAsync(UserResponseModel user, string htmlDataToMap); 
    }
}
