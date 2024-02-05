using System.ComponentModel.DataAnnotations;

namespace NotificationAPI.Models.RequestViewModels
{
    public class UserResponseModel
    {
        public string Name { get; set; }
        [Key]
        public string PolicyNumber { get; set; }
        public string Email { get; set; }
    }
}
