using NotificationAPI.Models.RequestViewModels;
using NotificationAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Net.Mime;

namespace NotificationAPI.Services.Implementations
{
    public class HttpService : IHttpService
    {
        private readonly string _apiUrl;
        private readonly IGenericHttpService _genericHttpService; 
        public HttpService(IConfiguration configuration , IServiceProvider serviceProvider)
        {
            _apiUrl = configuration["DocumentAPISettings:ApiUrl"]; 
            _genericHttpService = serviceProvider.GetRequiredService<IGenericHttpService>();
        }

        public async Task<int> SendUserDataAsync(UserRequestModel user)
        {
            string jsonData = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(jsonData , Encoding.UTF8 , MediaTypeNames.Application.Json);
            int result = await _genericHttpService.SendUserDataAsync(_apiUrl , HttpMethod.Post,  content);
            return result; 
        }
    }
}
