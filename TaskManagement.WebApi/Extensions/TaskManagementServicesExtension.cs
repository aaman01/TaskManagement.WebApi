using TaskManagement.WebApi.Services;
using TaskManagement.WebApi.Services.Interfaces;

namespace TaskManagement.WebApi.Extensions;

internal static class TaskManagementServicesExtension
{
    /// <summary>
    /// Configures the services.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddTaskManagementService(this IServiceCollection services)
    {
        services.AddScoped<ITaskService, TaskService>();
    }
}