using System.ComponentModel.DataAnnotations;

namespace PopulateHtmlDataApi.DAL.Entities
{
    public class HtmlTemplateEntity
    {
        [Key]
        public int ID {get; set;}
        public string Name { get; set;}
        public DateTime ModifiedDateTime {  get; set;} = DateTime.Now;

        public DateTime CreatedDateTime {  get; set;} = DateTime.Now;
        public string Content { get; set;}
        public string ContentBinary { get; set; } = " ";

        public bool IsDeleted { get; set; } = false; 
    }
}
