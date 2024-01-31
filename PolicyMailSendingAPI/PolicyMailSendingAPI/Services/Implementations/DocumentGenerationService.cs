using PolicyMailSendingAPI.Models.RequestViewModels;
using PolicyMailSendingAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace PolicyMailSendingAPI.Services.Implementations
{
    public class DocumentGenerationService : IDocumentGenerationService
    {
        private readonly HttpClient httpClient; 

        public DocumentGenerationService(HttpClient httpClient)
        {
            this.httpClient = new HttpClient(); 
        }

        public async Task SendUserData(UserRequestModel user)
        {
            string apiUrl = "http://localhost:63057/DocumentGeneration/GenerateDocument"; 
            string jsonData = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonData , Encoding.UTF8 , "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content); 
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data sent successfully"); 
            }
        }
    }
}
