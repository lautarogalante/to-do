using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("/api/todo")]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("task/{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await taskService.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateTask([FromBody] Tasks task)
        {
            var newTask = await taskService.CreateTask(task);
            return Ok(newTask);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Tasks task)
        {
            var updateTask = await taskService.UpdateTask(id, task);
            return Ok(updateTask);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deletedTask = await taskService.DeleteTask(id);
            return Ok(deletedTask);
        }
    }
}
