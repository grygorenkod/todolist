using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Repository.Entities;
#nullable disable

namespace ToDoList.DAL
{
    public class ToDoListDBContext : DbContext
    {
        public virtual DbSet<ToDo> ToDo { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        public ToDoListDBContext() { }
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options) : base(options) { }
    }
}
