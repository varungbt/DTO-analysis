namespace TodoApi.Models
{
    public class TodoItem
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}