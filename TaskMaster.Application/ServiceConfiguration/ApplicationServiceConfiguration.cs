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
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IIssueService,IssueService>();
        services.AddScoped<IServiceManager, ServiceManager>();

    }
}
