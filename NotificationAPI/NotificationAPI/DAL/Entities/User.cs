using System.ComponentModel.DataAnnotations;

namespace NotificationAPI.DAL.Entities
{
    public class User
    {
        public string Name { get; set; }

        [Key]
        public string PolicyNumber { get; set; }
        public string Email { get; set; }
        public bool IsGenerated { get; set; } = false; 
    }
}
