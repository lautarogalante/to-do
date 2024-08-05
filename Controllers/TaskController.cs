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
            if(!tasks.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, tasks.ErrorMessage);
            }
            return Ok(tasks);
        }

        [HttpGet]
        [Route("task/{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await taskService.GetTaskById(id);
            if (!task.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, task.ErrorMessage);

            }
            return Ok(task);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateTask([FromBody] Tasks task)
        {
            var newTask = await taskService.CreateTask(task);
            if (!newTask.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, newTask.ErrorMessage);
            }
            return StatusCode(StatusCodes.Status201Created, newTask);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Tasks task)
        {
            var updateTask = await taskService.UpdateTask(id, task);
            if (!updateTask.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, updateTask.ErrorMessage);
            }
            return Ok(updateTask);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deletedTask = await taskService.DeleteTask(id);
            if (!deletedTask.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, deletedTask.ErrorMessage);
            }
            return Ok(deletedTask);
        }
    }
}
