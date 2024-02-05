using System.ComponentModel.DataAnnotations;

namespace NotificationAPI.Models.RequestViewModels
{
    public class UserResponseModel
    {
        public string Name { get; set; }
        public string PolicyNumber { get; set; }
        public string Email { get; set; }
    }
}
