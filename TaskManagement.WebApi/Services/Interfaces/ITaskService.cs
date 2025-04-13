using TaskManagement.WebApi.Models.RequestModel;
using TaskManagement.WebApi.Models.ResponseModel;

namespace TaskManagement.WebApi.Services.Interfaces;

public interface ITaskService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TaskResponseModel>> GetAll();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TaskResponseModel> Get(long id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="taskRequestModel"></param>
    /// <returns></returns>
    Task<TaskResponseModel> Create(TaskRequestModel taskRequestModel);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="TaskRequestModel"></param>
    void Update(long id, TaskRequestModel taskUpdateRequestModel);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    void Delete(long id);



}
