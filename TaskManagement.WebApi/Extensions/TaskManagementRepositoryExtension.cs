using TaskManagement.WebApi.Repository;
using TaskManagement.WebApi.Repository.Interfaces;

namespace TaskManagement.WebApi.Extensions;

internal static class TaskManagementRepositoryExtension
{
    /// <summary>
    /// Configures the repository.
    /// </summary>
    /// <param name="services">The repository.</param>
    public static void AddTaskManagementRepository(this IServiceCollection services)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();
    }
}