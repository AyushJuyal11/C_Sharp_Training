using HandlebarsDotNet;
using PopulateHtmlDataApi.Models.ResponseViewModels;
using PopulateHtmlDataApi.Services.Interfaces;

namespace PopulateHtmlDataApi.Services.Implementations
{
    public class PopulateHtmlDataService : IPopulateHtmlDataService
    {
        public string PopulateHtmlData(string htmlData , UserResponseModel user)
        {
            HandlebarsTemplate<object, object> template = Handlebars.Compile(htmlData);
            string mappedHtmlData = template(user);
            return mappedHtmlData;
        }

    }
}
