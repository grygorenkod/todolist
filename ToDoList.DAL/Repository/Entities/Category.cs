using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace ToDoList.DAL.Repository.Entities
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            ToDos = new HashSet<ToDo>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
       
        public virtual ICollection<ToDo> ToDos { get; set; }
    }
}