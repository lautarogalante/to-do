using Microsoft.AspNetCore.Components.Web;
using ToDoList.Models;

namespace ToDoList.Data.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Tasks?>> GetAllTasks();
        Task<Tasks?> GetTaskById(int id);
        Task<Tasks?> CreateTask(Tasks task);
        Task<Tasks?> UpdateTask(int id, Tasks task);
        Task<Tasks?> DeleteTask(int id);
    }
}
