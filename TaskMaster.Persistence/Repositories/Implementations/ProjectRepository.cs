using MongoDB.Driver;
using System.Linq.Expressions;
using TaskMaster.Core.Models;
using TaskMaster.Persistence.Data.Context;
using TaskMaster.Persistence.Data.Options;
using TaskMaster.Persistence.Repositories.Interfaces;

namespace TaskMaster.Persistence.Repositories.Implementations;

public class ProjectRepository : MongoContext<Project>, IProjectRepository
{
    public ProjectRepository(IMongoOption option) : base(option)
    {
    }

    public async Task CreateProjectAsync(Project project, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(document: project, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<Project>> GetProjectsAsync(Expression<Func<Project, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        return filter is not null ? await Collection.Find<Project>(filter: filter).ToListAsync(cancellationToken)
                              : await Collection.Find<Project>(x => true).ToListAsync(cancellationToken);
    }

    public async Task UpdateProjectAsync(Project project, CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(filter: x => x.Id == project.Id, replacement: project, cancellationToken: cancellationToken);
    }
}
