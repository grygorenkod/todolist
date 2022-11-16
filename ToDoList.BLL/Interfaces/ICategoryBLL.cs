using ToDoList.BLL.Models;

namespace ToDoList.BLL.Interfaces
{
    public interface ICategoryBLL
    {
        Task<List<CategoryModel>> GetCategoryListAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryModel categoryModel);
        Task UpdateCategoryAsync(CategoryModel categoryModel);
        Task<int> DeleteCategoryAsync(int id);
    }
}
