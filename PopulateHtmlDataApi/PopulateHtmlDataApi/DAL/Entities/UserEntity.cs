using System.ComponentModel.DataAnnotations;

namespace PopulateHtmlDataApi.DAL.Entities
{
    public class UserEntity
    {
        public string Name { get; set; }
        [Key]
        public string PolicyNumber { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Occupation { get; set; }
        public string ProductCode { get; set; }
        public DateTime PolicyExpirationDate { get; set; }
        public string Email { get; set; }
    }
}
