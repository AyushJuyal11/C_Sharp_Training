namespace PopulateHtmlDataApi.Models.ResponseViewModels
{
    public class HtmlTemplateResponseModel
    {
        public int ID {get; set;}
        public string Name { get; set;}
        public DateTime ModifiedDatetime {  get; set;}
        public DateTime CreationDatetime {  get; set;}
        public string Content { get; set;}
        public string BinaryContent { get; set; } 
        public bool IsDeleted { get; set;}

    }
}
