using ToDoList.DAL;
using ToDoList.DAL.Repository.Entities;
using ToDoList.BLL.Models;
using ToDoList.BLL.AutoMapper;
using ToDoList.BLL.Interfaces;
using ToDoList.DAL.Interfaces;

namespace ToDoList.BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryBLL(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public async Task<List<CategoryModel>> GetCategoryListAsync()
        {
            var categoryEntities = await _categoryDAL.GetCategoryListAsync();
            List<CategoryModel> categoryModels = CustomAutoMapper<Category, CategoryModel>.MapList(categoryEntities);
            return categoryModels;
        }
        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            var categoryEntity = await _categoryDAL.GetCategoryByIdAsync(id);
            CategoryModel categoryModel = CustomAutoMapper<Category, CategoryModel>.Map(categoryEntity);
            return categoryModel;
        }

        public async Task AddCategoryAsync(CategoryModel categoryModel)
        {
            Category categoryEntity = CustomAutoMapper<CategoryModel, Category>.Map(categoryModel);
            await _categoryDAL.AddCategoryAsync(categoryEntity);
        }

        public async Task UpdateCategoryAsync(CategoryModel categoryModel)
        {
            Category categoryEntity = CustomAutoMapper<CategoryModel, Category>.Map(categoryModel);
            await _categoryDAL.UpdateCategoryAsync(categoryEntity);
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await _categoryDAL.DeleteCategoryAsync(id);
        }
    }
}