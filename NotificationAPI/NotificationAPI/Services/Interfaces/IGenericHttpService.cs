namespace NotificationAPI.Services.Interfaces
{
    public interface IGenericHttpService
    {
        Task<int> SendUserData(string apiUrl, HttpMethod httpMethod, StringContent content); 
    }
}
