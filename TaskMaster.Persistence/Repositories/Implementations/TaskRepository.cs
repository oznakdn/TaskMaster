using MongoDB.Driver;
using System.Linq.Expressions;
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

    public async Task<IEnumerable<ProjectTask>> GetTasksAsync(Expression<Func<ProjectTask, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        return filter is not null ? await Collection.Find<ProjectTask>(filter: filter).ToListAsync(cancellationToken)
                             : await Collection.Find<ProjectTask>(x => true).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<ProjectTask>> GetTasksByProjectId(string projectId, CancellationToken cancellationToken = default)
    {
        return await Collection.Find<ProjectTask>(x => x.ProjectId == projectId).ToListAsync();
    }

    public async Task UpdateTaskAsync(ProjectTask projectTask, CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(filter: x => x.Id == projectTask.Id, replacement: projectTask, cancellationToken: cancellationToken);
    }
}

