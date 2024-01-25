namespace PopulateHtmlDataApi.Models.RequestViewModels
{
    public class UserRequestModel
    {
        public string Name { get; set; }
        public string PolicyNumber { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Occupation { get; set; }
        public string ProductCode { get; set; }
        public DateTime PolicyExpirationDate { get; set; }
        public string Email { get; set; }

    }
}
