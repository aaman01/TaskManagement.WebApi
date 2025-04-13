using TaskManagement.WebApi.Models.RequestModel;
using TaskManagement.WebApi.Models.ResponseModel;

namespace TaskManagement.WebApi.Services.Interfaces;

public interface ITaskService
{
    /// <summary>
    /// Get all the task
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TaskResponseModel>> GetAll();

    /// <summary>
    /// Get a specific task
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TaskResponseModel> Get(long id);

    /// <summary>
    /// Create a task
    /// </summary>
    /// <param name="taskRequestModel"></param>
    /// <returns></returns>
    Task<TaskResponseModel> Create(TaskRequestModel taskRequestModel);

    /// <summary>
    /// Update a task
    /// </summary>
    /// <param name="TaskRequestModel"></param>
    Task Update(long id, TaskRequestModel taskUpdateRequestModel);
    
    /// <summary>
    /// Delete a tasl
    /// </summary>
    /// <param name="id"></param>
    Task Delete(long id);
}
