using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data.Repository
{
    public class TaskRepository: ITaskRepository
    {
        private readonly TaskDbContext taskDbContext;

        public TaskRepository(TaskDbContext taskDbContext)
        {
            this.taskDbContext = taskDbContext;
        }

        public async Task<Tasks?> CreateTask(Tasks task)
        {
            var toDo = await taskDbContext.Tasks.AddAsync(task);
            await taskDbContext.SaveChangesAsync();
            return toDo.Entity; 
        }

        public async Task<IEnumerable<Tasks?>> GetAllTasks()
        {
            return await taskDbContext.Tasks.ToListAsync();
        }

        public async Task<Tasks?> GetTaskById(int id)
        {
            return await taskDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Tasks?> UpdateTask(int id, Tasks tasks)
        {
            var updateTask = await taskDbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id);
            if (updateTask != null)
            {
                updateTask.Name = tasks.Name;
                updateTask.Title = tasks.Title;
                updateTask.Description = tasks.Description;
                updateTask.IsCompleted = tasks.IsCompleted;
                updateTask.CreatedAt = tasks.CreatedAt;
            }
            await taskDbContext.SaveChangesAsync();
            return updateTask;
        }

        public async Task<Tasks?> DeleteTask(int id)
        {
            var taskToDelete = await taskDbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id);
            if(taskToDelete != null)
            {
                taskDbContext.Tasks.Remove(taskToDelete);
                int affectedRows = await taskDbContext.SaveChangesAsync();
                if(affectedRows > 0)
                {
                    return taskToDelete;
                }
                
            }
            return null;
        }

    }
}
