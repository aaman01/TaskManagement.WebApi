using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.WebApi.Models.RequestModel;
using TaskManagement.WebApi.Services.Interfaces;

namespace TaskManagement.WebApi.Controllers;

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
    /// Get all the tasks
    /// </summary>
    /// <returns>List of task</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskService.GetAll();
        return Ok(tasks);
    }

    /// <summary>
    /// Gets a particular task
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A task</returns>
    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var task = await _taskService.Get(id);
            return Ok(task);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    /// <summary>
    /// Create a task
    /// </summary>
    /// <param name="taskRequestModel"></param>
    /// <returns>Created task Id</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskRequestModel taskRequestModel)
    {
        try
        {
            var createdTask = await _taskService.Create(taskRequestModel);
            return CreatedAtAction(nameof(Get), new { id = createdTask.Id }, createdTask);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update a task
    /// </summary>
    /// <param name="TaskRequestModel"></param>
    /// <returns>HTTP status code</returns>
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] TaskRequestModel taskRequestModel)
    {
        try
        {
            await _taskService.Update(id, taskRequestModel);
            return Ok("Task updated");
        }
        catch (ArgumentNullException e)
        {
            return BadRequest(e.Message);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    /// <summary>
    /// Delete a task
    /// </summary>
    /// <returns>HTTP status code</returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _taskService.Delete(id);
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
