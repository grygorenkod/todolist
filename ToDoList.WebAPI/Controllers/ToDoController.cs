using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.Models;
using ToDoList.BLL.Interfaces;

namespace ToDoList.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoBLL _toDoBLL;
        public ToDoController(IToDoBLL toDoBLL)
        {
            _toDoBLL = toDoBLL;
        }

        [HttpGet]
        [Route("getToDo")]
        public async Task<IActionResult> GetToDoListAsync()
        {
            var list = await _toDoBLL.GetToDoListAsync();
            if (list == null)
                return NotFound();
            return Ok(list);

        }
        [HttpGet]
        [Route("getToDo/id")]
        public async Task<IActionResult> GetToDoByIdAsync(int id)
        {
            var toDoModel = await _toDoBLL.GetToDoByIdAsync(id);
            if (toDoModel == null)
                return NotFound();
            return Ok(toDoModel);
        }

        [HttpPost]
        [Route("postToDo")]
        public async Task<IActionResult> AddToDoAsync(ToDoModel toDoModel)
        {
            if (ModelState.IsValid)
            {
                await _toDoBLL.AddToDoAsync(toDoModel);
                return Ok(toDoModel);
            }
                
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("putToDo")]
        public async Task<IActionResult> UpdateToDoAsync(ToDoModel toDoModel)
        {
            if (ModelState.IsValid)
            {
                await _toDoBLL.UpdateToDoAsync(toDoModel);
                return Ok(toDoModel);
            } 
            return NotFound(ModelState);
        }

        [HttpDelete]
        [Route("deleteToDo")]
        public async Task<IActionResult> DeleteToDoAsync(int id)
        {
            var toDo = await GetToDoByIdAsync(id);
            if (toDo != null)
            {
                await _toDoBLL.DeleteToDoAsync(id);
                return Ok(toDo);
            }
            return NotFound(id);
        }
    }
}
