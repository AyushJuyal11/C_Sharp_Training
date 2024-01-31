using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.DAL.Repositories.Interfaces;
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
            int result = await _documentRepository.AddDocumentAsync(document);
            if (result == -1) throw new Exception("Not found");
            else return 1; 
        }
    }
}
