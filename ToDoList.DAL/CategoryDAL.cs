using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Repository.Entities;
using ToDoList.DAL.Interfaces;
#nullable disable

namespace ToDoList.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly ToDoListDBContext _db;
        public CategoryDAL(ToDoListDBContext dBContext)
        {
            _db = dBContext;
        }

        public async Task<List<Category>> GetCategoryListAsync()
        {
            return await _db.Category.ToListAsync();
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _db.Category.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _db.AddAsync(category);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _db.Update(category);
            await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            var categoryId = await GetCategoryByIdAsync(id);
            _db.Category.Remove(categoryId);
            return await _db.SaveChangesAsync();
        }
    }
}
    