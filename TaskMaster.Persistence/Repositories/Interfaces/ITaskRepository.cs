using TaskMaster.Core.Models;

namespace TaskMaster.Persistence.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<ProjectTask>> GetTasksByProjectId(string projectId, CancellationToken cancellationToken = default(CancellationToken));
    Task CreateTaskAsync(ProjectTask projectTask, CancellationToken cancellationToken = default(CancellationToken));
}
