using PopulateHtmlDataApi.DAL.Entities;

namespace PopulateHtmlDataApi.DAL.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task<int> AddDocumentAsync(DocumentEntity documentEntity);
    }
}
