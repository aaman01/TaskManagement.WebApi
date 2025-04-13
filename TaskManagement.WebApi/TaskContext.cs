using Microsoft.EntityFrameworkCore;

namespace TaskManagement.WebApi
{
    /// <summary>
    /// The TaskContext class is a DbContext derived class used to interact with the task-related database entities.
    /// </summary>
    /// <param name="options"></param>
    public class TaskContext(DbContextOptions<TaskContext> options):DbContext(options)
    {
        /// <summary>
        /// Represents the collection of task entities.
        /// </summary>
        public DbSet<Task> Tasks { get; init; }
    }
}
