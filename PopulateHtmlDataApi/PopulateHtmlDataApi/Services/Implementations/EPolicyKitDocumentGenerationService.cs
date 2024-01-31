using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.Models.ResponseViewModels;
using PopulateHtmlDataApi.Services.Interfaces;

namespace PopulateHtmlDataApi.Services.Implementations
{
    public class EPolicyKitDocumentGenerationService : IEPolicyKitDocumentGenerationService
    {
        private readonly IPopulateHtmlDataService _populateHtmlDataService;
        private readonly IConvertToPdfService _convertToPdfService;

        public EPolicyKitDocumentGenerationService(IConvertToPdfService convertToPdfService ,  IPopulateHtmlDataService populateHtmlDataService)
        {
            _convertToPdfService=convertToPdfService;
            _populateHtmlDataService = populateHtmlDataService;
        }

        public async Task<DocumentEntity> GenerateDocumentAsync(UserResponseModel user, string htmlDataToMap)
        {
            string mappedHtmlData = _populateHtmlDataService.PopulateHtmlData(htmlDataToMap, user);
            byte[] mappedHtmlByte =  await _convertToPdfService.GetByteDataAsync(mappedHtmlData);
            if (mappedHtmlByte == null) throw new Exception("Bad request");
            DocumentEntity document = new();
            document.ObjectCode = user.PolicyNumber + "-" + user.ProductCode; 
            document.ReferenceNumber = user.PolicyNumber;
            document.Content = mappedHtmlByte;
            document.FileName = user.PolicyNumber + DateTime.Now.ToString(); 
            return document;
        }
    }
}
