using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TaskMaster.Persistence.Data.Options;
using TaskMaster.Persistence.Manager;
using TaskMaster.Persistence.Repositories.Implementations;
using TaskMaster.Persistence.Repositories.Interfaces;

namespace TaskMaster.Persistence.ServiceConfiguration;

public static class PersistenceServiceConfiguration
{
    public static void AddPersistenceService(this IServiceCollection service, IConfiguration configuration)
    {
        service.Configure<MongoOption>(configuration.GetSection(nameof(MongoOption)));
        service.AddSingleton<IMongoOption>(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);

        service.AddScoped<IProjectRepository, ProjectRepository>();
        service.AddScoped<ITaskRepository, TaskRepository>();
        service.AddScoped<IRepositoryManager, RepositoryManager>();
        service.AddScoped<IProjectIssueRepository, ProjectIssueRepository>();

    }
}
