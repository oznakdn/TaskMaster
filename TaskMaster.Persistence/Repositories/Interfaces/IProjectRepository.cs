using System.Linq.Expressions;
using TaskMaster.Core.Models;

namespace TaskMaster.Persistence.Repositories.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetProjectsAsync(Expression<Func<Project, bool>> filter = null, CancellationToken cancellationToken = default(CancellationToken));
    Task CreateProjectAsync(Project project, CancellationToken cancellationToken = default(CancellationToken));
    Task UpdateProjectAsync(Project project, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteProjectAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

}
