using ReflectionTask.CustomAttributes;
using System.Globalization;

namespace ReflectionTask.Models
{
    public class Employee
    {
        private string _policyExpiryDate;
        [MapHtmlData("{{name}}")]
        public string Name { get; set; }

        [MapHtmlData("[[age]]")]
        public int Age { get; set; }

        [MapHtmlData("{{PolNumber}}")]
        public string PolicyNumber { get; set; }

        [MapHtmlData("{{Salary}}")]
        public int Salary { get; set; }

        [MapHtmlData("{{Occupation}}")]
        public string Occupation { get; set; }

        [MapHtmlData("{{ProductCode}}")]
        public string ProductCode { get; set; }

        [MapHtmlData("{{PolicyExpiryDate}}")]
        public string PolicyExpiryDate { set { _policyExpiryDate = value; } get { return DateTime.ParseExact(_policyExpiryDate, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"); } }

        public Employee() { }

        public Employee(string Name, int Age, string PolicyNumber, int Salary, string Occupation, string ProductCode , string PolicyExpiryDate)
        {
            this.Name = Name;
            this.Age = Age;
            this.PolicyNumber = PolicyNumber;
            this.Salary = Salary;
            this.Occupation = Occupation;
            this.ProductCode = ProductCode;
            this.PolicyExpiryDate = PolicyExpiryDate;
        }
    }
}
