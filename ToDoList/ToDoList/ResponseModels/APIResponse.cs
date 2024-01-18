namespace ToDoList.ResponseModels
{
    public class APIResponse
    {
        public string Code { get; set; } = "200";
        public string Message { get; set; } = "Success"; 
        public object Body { get; set; }
        public object Errors { get; set; } = null;
        public string TimeStamp { get; set; } = DateTime.UtcNow.ToString(); 
        public string CorelationID { get; set; } = Guid.NewGuid().ToString();
    }
}
