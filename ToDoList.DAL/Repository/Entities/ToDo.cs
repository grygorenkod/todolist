using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace ToDoList.DAL.Repository.Entities
{
    [Table("ToDo")]
    public class ToDo
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(50)]
        public string? Description { get; set; }
        [Column("is_done")]
        public bool? IsDone { get; set; }
        
        public virtual Category Category { get; set; }
    }
}
