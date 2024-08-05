using ToDoList.Data.Repository;
using ToDoList.Models;

namespace ToDoList.Services
{

    public class TaskService: ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository) { 
            this.taskRepository = taskRepository;
        }

        public async Task<Result<Tasks?>> CreateTask(Tasks task)
        {
            task.CreatedAt = DateTime.Now;
            var newTask = await taskRepository.CreateTask(task);
            if (newTask == null)
            {
                return Result<Tasks?>.ErrorResult("The task could not be created.");
            }
            return Result<Tasks?>.SuccessResult(newTask);
        }

        public async Task<Result<IEnumerable<Tasks?>>> GetAllTasks()
        {
            var getTask = await taskRepository.GetAllTasks();
            if (getTask == null)
            {
                return Result<IEnumerable<Tasks?>>.ErrorResult("Error when obtaining tasks.");

                    
            }
            return Result<IEnumerable<Tasks?>>.SuccessResult(getTask);

        }

        public async Task<Result<Tasks?>> GetTaskById(int id)
        {
            var task = await taskRepository.GetTaskById(id);
            if (task == null)
            {
                return Result<Tasks?>.ErrorResult("Error when obtaining the task.");
            }
            return Result<Tasks?>.SuccessResult(task); 
        }

        public async Task<Result<Tasks?>> UpdateTask(int id, Tasks task)
        {
            task.CreatedAt = DateTime.Now;
            var updateTask = await taskRepository.UpdateTask(id, task);
            if (updateTask == null)
            {
                return Result<Tasks?>.ErrorResult("Error when updating the task.");
            }
            return Result<Tasks?>.SuccessResult(updateTask);
 
        }

        public async Task<Result<Tasks?>> DeleteTask(int id)
        {
            var exist = await taskRepository.DeleteTask(id);
            if (exist == null)
            {
                return Result<Tasks?>.ErrorResult("Task not found.");
            }
            return Result<Tasks?>.SuccessResult(exist);

        }
    }
}
