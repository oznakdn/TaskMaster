using TaskMaster.Persistence.Repositories.Interfaces;

namespace TaskMaster.Persistence.Manager;

public class RepositoryManager : IRepositoryManager
{
    private readonly IProjectRepository _project;
    private readonly ITaskRepository _task;
    public RepositoryManager(IProjectRepository project, ITaskRepository task)
    {
        _project = project;
        _task = task;
    }

    public IProjectRepository Project => _project;

    public ITaskRepository Task => _task;
}
