using PopulateHtmlDataApi.Models.ResponseViewModels;

namespace PopulateHtmlDataApi.Services.Interfaces
{
    public interface IHtmlTemplateService
    {
        Task<HtmlTemplateResponseModel> GetHtmlTemplateByIdAsync(int ID);
    }
}
