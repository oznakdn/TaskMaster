using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskMaster.Application.Manager;
using TaskMaster.Application.Services.Implementations;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Persistence.ServiceConfiguration;

namespace TaskMaster.Application.ServiceConfiguration;

public static class ApplicationServiceConfiguration
{
    public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceService(configuration);
        services.AddTransient<IProjectService, ProjectService>();
        services.AddTransient<ITaskService, TaskService>();
        services.AddScoped<IServiceManager, ServiceManager>();
    }
}
