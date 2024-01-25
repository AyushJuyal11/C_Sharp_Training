using PopulateHtmlDataApi.DAL.Entities;

namespace PopulateHtmlDataApi.DAL.Repositories.Interfaces
{
    public interface IHtmlTemplateRepository
    {
        public Task<HtmlTemplateEntity> GetHtmlTemplateEntityByIdAsync(int ID);

    }
}
