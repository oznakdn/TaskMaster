using TaskMaster.Application.Services.Interfaces;

namespace TaskMaster.Application.Manager;

public class ServiceManager : IServiceManager
{
    private readonly IProjectService _project;
    private readonly ITaskService _task;
    public ServiceManager(IProjectService project, ITaskService task)
    {
        _project = project;
        _task = task;
    }

    public IProjectService Project => _project;

    public ITaskService Task => _task;

}
