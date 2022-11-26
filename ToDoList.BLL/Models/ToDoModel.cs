#nullable disable

namespace ToDoList.BLL.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsDone { get; set; }
        public int? CategoryId { get; set; }
    }
}
