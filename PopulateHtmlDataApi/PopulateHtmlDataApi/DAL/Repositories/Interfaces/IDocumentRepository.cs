using PopulateHtmlDataApi.DAL.Entities;

namespace PopulateHtmlDataApi.DAL.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task<DocumentEntity> AddDocumentAsync(DocumentEntity documentEntity);
    }
}
