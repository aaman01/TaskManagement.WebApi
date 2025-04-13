using Microsoft.EntityFrameworkCore;
using TaskManagement.WebApi.Repository.Interfaces;

namespace TaskManagement.WebApi.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<Models.Entities.Task>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        ///<inheritdoc/>
        public async Task<Models.Entities.Task?> Get(long id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        ///<inheritdoc/>
        public async Task<Models.Entities.Task> Create(Models.Entities.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        ///<inheritdoc/>
        public async Task Delete(Models.Entities.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task Update(Models.Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
