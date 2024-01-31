using Microsoft.EntityFrameworkCore;
using PopulateHtmlDataApi.DAL.DbContexts;
using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.DAL.Repositories.Interfaces;
using System.Linq;

namespace PopulateHtmlDataApi.DAL.Repositories.Implementations
{
    public class HtmlTemplateRepository(ApplicationDbContext context) : IHtmlTemplateRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<HtmlTemplateEntity> GetHtmlTemplateEntityByIdAsync(int ID)
        {
            HtmlTemplateEntity requiredHtmlTemplateEntity = await _context.HtmlTemplates.FindAsync(ID); 
            return requiredHtmlTemplateEntity;
        }
        
    }
}
