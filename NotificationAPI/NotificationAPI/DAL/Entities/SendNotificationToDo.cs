using Microsoft.EntityFrameworkCore;

namespace NotificationAPI.DAL.Entities
{
    [Keyless]
    public class SendNotificationToDo
    {
        public byte[] Content { get; set; }
        public string Name { get; set; }
        public string PolicyNumber { get; set; }
        public string Email { get; set; }
        public bool IsGenerated { get; set; } = false; 
    }
}
