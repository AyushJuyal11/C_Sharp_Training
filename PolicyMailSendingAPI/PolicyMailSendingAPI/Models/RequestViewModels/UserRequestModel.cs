using System.ComponentModel.DataAnnotations;

namespace PolicyMailSendingAPI.Models.RequestViewModels
{
    public class UserRequestModel
    {
        public string Name { get; set; }

        public string PolicyNumber { get; set; }
        public string Email { get; set; }
    }
}
