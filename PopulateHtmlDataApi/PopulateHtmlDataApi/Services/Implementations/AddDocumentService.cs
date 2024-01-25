using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.DAL.Repositories.Interfaces;
using PopulateHtmlDataApi.Models.ResponseViewModels;
using PopulateHtmlDataApi.Services.Interfaces;

namespace PopulateHtmlDataApi.Services.Implementations
{
    public class AddDocumentService : IAddDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public AddDocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository=documentRepository;
        }

        public async Task<int> AddDocumentAsync(DocumentEntity document)
        {
            var result = await _documentRepository.AddDocumentAsync(document);
            if (result == null) throw new Exception("Not found");
            else return 1; 
        }
    }
}
