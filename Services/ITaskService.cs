using System.Threading.Tasks;
using ToDoList.Data.Repository;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITaskService
    {
        Task<Result<IEnumerable<Tasks?>>> GetAllTasks();
        Task<Result<Tasks?>> GetTaskById(int id);
        Task<Result<Tasks?>> CreateTask(Tasks task);
        Task<Result<Tasks?>> UpdateTask(int id, Tasks task);
        Task<Result<Tasks?>> DeleteTask(int id);
    }
}
