namespace ToDoList.Models.RequestViewModels
{
    public class ToDoItemRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
