using ToDoList.BLL.Models;

namespace ToDoList.BLL.Interfaces
{
    public interface IToDoBLL
    {
        Task<List<ToDoModel>> GetToDoListAsync();
        Task<ToDoModel> GetToDoByIdAsync(int id);
        Task AddToDoAsync(ToDoModel toDoModel);
        Task UpdateToDoAsync(ToDoModel toDoModel);
        Task<int> DeleteToDoAsync(int id);
    }
}
