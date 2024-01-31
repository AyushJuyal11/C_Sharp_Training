using System.ComponentModel.DataAnnotations;

namespace PopulateHtmlDataApi.DAL.Entities
{
    public class DocumentEntity
    {
        [Key]
        public string ObjectCode { get; set;  } // $"{PolicyNumber} -(hyphen) {ProductCode}" 
        public string ReferenceType { get; set; } = "Policy";
        public string ReferenceNumber { get; set; }  //PolicyNumber,            
        public byte[] Content { get; set; }
        public string FileName { get; set; } // $"{PolicyNumber}" + DateTime.Now.ToString(),       
        public string FileExtension { get; set; } = ".pdf";
        public string LanguageCode { get; set;  } = "km-KH";
        public string CreatedUser { get; set; } = "";
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow; 
        public bool IsDeleted { get; set; } = false;

    }
}
