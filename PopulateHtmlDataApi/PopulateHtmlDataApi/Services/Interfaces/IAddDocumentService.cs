using PopulateHtmlDataApi.DAL.Entities;

namespace PopulateHtmlDataApi.Services.Interfaces
{
    public interface IAddDocumentService
    {
        Task<int> AddDocumentAsync(DocumentEntity document); 
    }
}
