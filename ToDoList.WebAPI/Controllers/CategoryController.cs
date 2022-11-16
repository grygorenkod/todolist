﻿using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL;
using ToDoList.BLL.Models;

namespace ToDoList.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryBLL _categoryBLL;
        public CategoryController(CategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }

        [HttpGet]
        [Route("getCategory")]
        public async Task<IActionResult> GetCategoryListAsync()
        {
            var list = await _categoryBLL.GetCategoryListAsync();
            if (list == null)
                return NotFound();
            return Ok(list);

        }
        [HttpGet]
        [Route("getCategory/id")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var categoryModel = await _categoryBLL.GetCategoryByIdAsync(id);
            if (categoryModel == null)
                return NotFound();
            return Ok(categoryModel);
        }

        [HttpPost]
        [Route("postCategory")]
        public async Task<IActionResult> AddCategoryAsync(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
                await _categoryBLL.AddCategoryAsync(categoryModel);
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("putCategory")]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
                await _categoryBLL.UpdateCategoryAsync(categoryModel);
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("deleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category != null)
                await _categoryBLL.DeleteCategoryAsync(id);
            return NotFound(id);
        }
    }
}
