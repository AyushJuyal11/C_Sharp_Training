using PopulateHtmlDataApi.Models.ResponseViewModels;

namespace PopulateHtmlDataApi.Services.Interfaces
{
    public interface IPopulateHtmlDataService
    {
        string PopulateHtmlData(string htmlData , UserResponseModel user);
    }
}
