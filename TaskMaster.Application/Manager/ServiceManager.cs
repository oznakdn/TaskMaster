using TaskMaster.Application.Services.Interfaces;

namespace TaskMaster.Application.Manager;

public class ServiceManager : IServiceManager
{
    private readonly IProjectService _project;
    private readonly ITaskService _task;
    private readonly IIssueService _issue;
    public ServiceManager(IProjectService project, ITaskService task, IIssueService issue)
    {
        _project = project;
        _task = task;
        _issue = issue;
    }

    public IProjectService Project => _project;

    public ITaskService Task => _task;

    public IIssueService Issue => _issue;
    
}
