using System.Linq.Expressions;
using TaskMaster.Core.Models;

namespace TaskMaster.Persistence.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<ProjectTask>> GetTasksByProjectId(string projectId, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<ProjectTask>> GetTasksAsync(Expression<Func<ProjectTask, bool>> filter = null,CancellationToken cancellationToken = default(CancellationToken));
    Task CreateTaskAsync(ProjectTask projectTask, CancellationToken cancellationToken = default(CancellationToken));
    Task UpdateTaskAsync(ProjectTask projectTask, CancellationToken cancellationToken = default(CancellationToken));

}
