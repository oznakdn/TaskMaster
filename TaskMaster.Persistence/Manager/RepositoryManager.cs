using TaskMaster.Persistence.Repositories.Interfaces;

namespace TaskMaster.Persistence.Manager;

public class RepositoryManager : IRepositoryManager
{
    private readonly IProjectRepository _project;
    private readonly ITaskRepository _task;
    private readonly IProjectIssueRepository _issue;

    public RepositoryManager(IProjectRepository project, ITaskRepository task, IProjectIssueRepository issue)
    {
        _project = project;
        _task = task;
        _issue = issue;
    }

    public IProjectRepository Project => _project;

    public ITaskRepository Task => _task;

    public IProjectIssueRepository Issue => _issue;
    
}
