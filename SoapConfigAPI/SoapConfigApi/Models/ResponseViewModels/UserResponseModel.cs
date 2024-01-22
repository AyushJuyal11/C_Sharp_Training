using System.Xml.Serialization;

namespace SoapConfigAPI.Models.ResponseViewModels
{

    public class UserResponseModel
    {
        [XmlElement("ProductType")]
        public string ProductType { get; set; }

        [XmlElement("PaymentMethod")]
        public string PaymentMethod { get; set; }

        [XmlElement("DateOfBirth")]
        public string DateOfBirth { get; set; }

        [XmlElement("Gender")]
        public string Gender { get; set; }
    }

    [XmlRoot(ElementName = "UserDetails")]
    public class UserResponseModelList
    {

        [XmlElement("User")]
        public List<UserResponseModel> Users { get; set; }
    }
}


