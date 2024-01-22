namespace SoapConfigAPI.Models.ResponseViewModels
{
    public class SoapConfigResponse
    { 
        public int ID { get; set; }
        public string Code { get; set; }
        public string XML { get; set; }
        public bool IsDeleted { get; set; }  = false;
        public DateTime CreationDateTime {  get; set; }

    }
}
