using MongoDB.Driver;
using TaskMaster.Core.Models;
using TaskMaster.Persistence.Data.Context;
using TaskMaster.Persistence.Data.Options;
using TaskMaster.Persistence.Repositories.Interfaces;

namespace TaskMaster.Persistence.Repositories.Implementations;

public class TaskRepository : MongoContext<ProjectTask>, ITaskRepository
{
    public TaskRepository(IMongoOption option) : base(option)
    {
    }

    public async Task CreateTaskAsync(ProjectTask projectTask, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(document: projectTask, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<ProjectTask>> GetTasksByProjectId(string projectId, CancellationToken cancellationToken = default)
    {
        return await Collection.Find<ProjectTask>(x => x.ProjectId == projectId).ToListAsync();
    }
}

