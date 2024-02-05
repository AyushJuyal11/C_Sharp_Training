using Newtonsoft.Json.Linq;
using NotificationAPI.Services.Interfaces;

namespace NotificationAPI.Services.Implementations
{
    public class GenericHttpService : IGenericHttpService
    {
        private readonly HttpClient _httpClient;

        public GenericHttpService(IServiceProvider serviceProvider) 
        {
            _httpClient = serviceProvider.GetRequiredService<HttpClient>();
        }
        public async Task<int> SendUserDataAsync(string apiUrl, HttpMethod httpMethod, StringContent content)
        {
            var request = new HttpRequestMessage(httpMethod , apiUrl);
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var jsonres = JObject.Parse(res);
                if (jsonres == null || !jsonres["Code"].ToString().Equals("200"))
                    return -1;

                Console.WriteLine("Data sent successfully");
            }
        return 1; 
        }
    }
}
