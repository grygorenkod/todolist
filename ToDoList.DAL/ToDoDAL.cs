using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Repository.Entities;
using ToDoList.DAL.Interfaces;
#nullable disable

namespace ToDoList.DAL
{
    public class ToDoDAL : IToDoDAL
    {
        private readonly ToDoListDBContext _db;
        public ToDoDAL(ToDoListDBContext dBContext)
        {
            _db = dBContext;
        }

        public async Task<List<ToDo>> GetToDoListAsync()
        {
            return await _db.ToDos.ToListAsync();
        }
        public async Task<ToDo> GetToDoByIdAsync(int id)
        {
            return await _db.ToDos.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddToDoAsync(ToDo todo)
        {
            await _db.AddAsync(todo);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateToDoAsync(ToDo todo)
        {
            _db.Update(todo);
            await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteToDoAsync(int id)
        {
            var todo = await GetToDoByIdAsync(id);
            _db.ToDos.Remove(todo);
            return await _db.SaveChangesAsync();
        }
    }
}
