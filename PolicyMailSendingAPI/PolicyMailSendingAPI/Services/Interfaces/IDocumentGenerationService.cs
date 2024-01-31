using PolicyMailSendingAPI.Models.RequestViewModels;

namespace PolicyMailSendingAPI.Services.Interfaces
{
    public interface IDocumentGenerationService
    {
        Task SendUserData(UserRequestModel user); 
    }
}
