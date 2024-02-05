namespace NotificationAPI.Services.Interfaces
{
    public interface IUpdateFlagService 
    {
        Task<int> UpdateIsGeneratedFlagAsync();
    }
}
