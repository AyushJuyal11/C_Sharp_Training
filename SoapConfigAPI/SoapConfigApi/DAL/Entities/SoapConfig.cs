namespace SoapConfigAPI.DAL.Entities
{
    public class SoapConfig
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string XML { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
