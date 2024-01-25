using PopulateHtmlDataApi.DAL.DbContexts;
using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.DAL.Repositories.Interfaces;

namespace PopulateHtmlDataApi.DAL.Repositories.Implementations
{
    public class DocumentRepository(ApplicationDbContext context) : IDocumentRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<DocumentEntity> AddDocumentAsync(DocumentEntity documentEntity)
        {
            _context.Documents.Add(documentEntity);
            await _context.SaveChangesAsync();
            return documentEntity;  
        }
    }
}
