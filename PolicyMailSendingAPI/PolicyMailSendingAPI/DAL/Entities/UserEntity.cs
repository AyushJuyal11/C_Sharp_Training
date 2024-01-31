using System.ComponentModel.DataAnnotations;

namespace PolicyMailSendingAPI.DAL.Entities
{
    public class UserEntity
    {
        public string Name { get; set; }

        [Key]
        public string PolicyNumber { get; set; }
        public string Email { get; set; }
        public bool IsGenerated { get; set; } = false; 
    }
}
