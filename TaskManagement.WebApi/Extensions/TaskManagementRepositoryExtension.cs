using TaskManagement.WebApi.Repository;
using TaskManagement.WebApi.Repository.Interfaces;

namespace TaskManagement.WebApi.Extensions;

internal static class TaskManagementRepositoryExtension
{
    /// <summary>
    /// Configures the services.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddTaskManagementRepository(this IServiceCollection services)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();
    }
}