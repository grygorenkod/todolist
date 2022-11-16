using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Repository.Entities;

namespace ToDoList.DAL.Interfaces
{
    public interface ICategoryDAL
    {
        Task<List<Category>> GetCategoryListAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task<int> DeleteCategoryAsync(int id);
    }
}
