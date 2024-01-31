using Microsoft.EntityFrameworkCore;

namespace PolicyMailSendingAPI.DAL.Entities
{
    [Keyless]
    public class ViewEntity
    {
        public byte[] Content { get; set; }
        public string Name { get; set; }
        public string PolicyNumber { get; set; }
        public string Email { get; set; }
        public bool IsGenerated { get; set; } = false; 
    }
}
