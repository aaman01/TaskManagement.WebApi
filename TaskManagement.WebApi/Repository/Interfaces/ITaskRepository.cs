namespace TaskManagement.WebApi.Repository.Interfaces
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Get all the tasks
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.Entities.Task>> GetAll();

        /// <summary>
        /// Get a specified task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Models.Entities.Task?> Get(long id);

        /// <summary>
        /// Creates a task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<Models.Entities.Task> Create(Models.Entities.Task task);

        /// <summary>
        /// Updates a task
        /// </summary>
        /// <param name="task"></param>
        Task Update(Models.Entities.Task task);

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="task"></param>
        Task Delete(Models.Entities.Task task);
    }
}
