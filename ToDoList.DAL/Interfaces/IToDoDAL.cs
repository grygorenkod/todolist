using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Repository.Entities;

namespace ToDoList.DAL.Interfaces
{
    public interface IToDoDAL
    {
        Task<List<ToDo>> GetToDoListAsync();
        Task<ToDo> GetToDoByIdAsync(int id);
        Task AddToDoAsync(ToDo todo);
        Task UpdateToDoAsync(ToDo todo);
        Task<int> DeleteToDoAsync(int id);
    }
}
