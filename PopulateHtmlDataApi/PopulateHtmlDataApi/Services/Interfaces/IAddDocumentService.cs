using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.Models.ResponseViewModels;

namespace PopulateHtmlDataApi.Services.Interfaces
{
    public interface IAddDocumentService
    {
        Task<int> AddDocumentAsync(DocumentEntity document); 
    }
}
