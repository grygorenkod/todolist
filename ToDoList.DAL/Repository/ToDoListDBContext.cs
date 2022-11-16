using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDoList.DAL.Repository.Entities;

namespace ToDoList.DAL
{
    public class ToDoListDBContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ToDoListDBContext() { }
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options) : base(options) { }
    }
}
