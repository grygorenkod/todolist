using ToDoList.BLL.AutoMapper;
using ToDoList.BLL.Models;
using ToDoList.DAL;
using ToDoList.DAL.Repository.Entities;
using ToDoList.BLL.Interfaces;

namespace ToDoList.BLL
{
    public class ToDoBLL : IToDoBLL
    {
        private readonly ToDoDAL _toDoDALL;
        public ToDoBLL(ToDoDAL toDoDAL)
        {
            _toDoDALL = toDoDAL;
        }

        public async Task<List<ToDoModel>> GetToDoListAsync()
        {
            var toDoEntities = await _toDoDALL.GetToDoListAsync();
            List<ToDoModel> toDoModels = CustomAutoMapper<ToDo, ToDoModel>.MapList(toDoEntities);
            return toDoModels;
        }
        public async Task<ToDoModel> GetToDoByIdAsync(int id)
        {
            var toDoEntity = await _toDoDALL.GetToDoByIdAsync(id);
            ToDoModel toDoModel = CustomAutoMapper<ToDo, ToDoModel>.Map(toDoEntity);
            return toDoModel;
        }

        public async Task AddToDoAsync(ToDoModel toDoModel)
        {
            ToDo toDoEntity = CustomAutoMapper<ToDoModel, ToDo>.Map(toDoModel);
            await _toDoDALL.AddToDoAsync(toDoEntity);
        }

        public async Task UpdateToDoAsync(ToDoModel toDoModel)
        {
            ToDo toDoEntity = CustomAutoMapper<ToDoModel, ToDo>.Map(toDoModel);
            await _toDoDALL.UpdateToDoAsync(toDoEntity);
        }

        public async Task<int> DeleteToDoAsync(int id)
        {
            return await _toDoDALL.DeleteToDoAsync(id);
        }
    }
}
