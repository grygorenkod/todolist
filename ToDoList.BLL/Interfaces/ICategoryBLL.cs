using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Models;

namespace ToDoList.BLL.Interfaces
{
    public interface ICategoryBLL
    {
        Task<List<CategoryModel>> GetCategoryListAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryModel categoryModel);
        Task UpdateCategoryAsync(CategoryModel categoryModel);
    }
}
