using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.WebApi.Controllers
{
    /// <summary>
    /// Task Management Controller
    /// </summary>
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _taskService.GetAll();
            return new JsonResult(tasks);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int id)
        {
            var task = _taskService.Get(id);
            return new JsonResult(task);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskRequestModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] TaskRequestModel taskRequestModel)
        {
            var createdId = _taskService.Create(taskRequestModel);
            return new CreatedResult(Uri.UriSchemeHttps, new { Id = createdId });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskUpdateRequestModel"></param>
        /// <returns></returns>
        [HttpPut("{id:long}")]
        public IActionResult Update([FromBody] TaskUpdateRequestModel taskUpdateRequestModel)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public IActionResult Delete()
        {

        }

    }
}
