﻿using System.Security.Cryptography.Xml;
using TaskManagement.WebApi.Models.RequestModel;
using TaskManagement.WebApi.Models.ResponseModel;
using TaskManagement.WebApi.Services.Interfaces;

namespace TaskManagement.WebApi.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    ///<inheritdoc/>
    public async Task<IEnumerable<TaskResponseModel>> GetAll()
    {
        try
        {
            var tasks = await _taskRepository.GetAll();

            var taskResponse = tasks.Select(t =>
            {
                var response = new TaskResponseModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    IsCompleted = t.IsCompleted
                };
            });

            return taskResponse;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    ///<inheritdoc/>
    public async Task<TaskResponseModel> Get(long id)
    {
        var task = await _taskRepository.Get(id);

        if (task == null)
        {
            throw new KeyNotFoundException("Task not found");
        }

        return new TaskResponseModel()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };
    }

    ///<inheritdoc/>
    public async Task<TaskResponseModel> Create(TaskRequestModel taskRequestModel)
    {
        if (string.IsNullOrEmpty(taskRequestModel.Title))
        {
            throw new ArgumentNullException("Task title cannot be null");
        }

        var task = new Models.Entities.Task()
        {
            Title = taskRequestModel.Title,
            Description = taskRequestModel.Description,
            DueDate = taskRequestModel.DueDate,
            IsCompleted = taskRequestModel.IsCompleted,
            CreatedAt = DateTime.UtcNow
        };

        await _taskRepository.Create(task);

        var taskResponse = new TaskResponseModel()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };

        return taskResponse;
    }

    ///<inheritdoc/>
    public async void Update(long id, TaskRequestModel taskRequestModel)
    {
        if (string.IsNullOrEmpty(taskRequestModel.Title))
        {
            throw new ArgumentNullException("Task title cannot be null");
        }

        var task = await _taskRepository.Get(id);

        if (task is null)
        {
            throw new KeyNotFoundException("Task not found");
        }

        task.title = taskRequestModel.Title;
        task.Description = taskRequestModel.Description;
        task.DueDate = taskRequestModel.DueDate;
        task.IsCompleted = taskRequestModel.IsCompleted;

        await _taskRepository.Update(task);
    }

    ///<inheritdoc/>
    public async void Delete(long id)
    {
        var task = await _taskRepository.Get(id);

        if (task is null)
            throw new KeyNotFoundException("Task not found");

        await _taskRepository.Delete(task);
    }
}
