namespace NotificationAPI.Services.Interfaces
{
    public interface IGenericHttpService
    {
        Task<int> SendUserDataAsync(string apiUrl, HttpMethod httpMethod, StringContent content); 
    }
}
