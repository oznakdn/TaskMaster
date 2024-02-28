using TaskMaster.Application.Services.Interfaces;

namespace TaskMaster.Application.Manager;

public interface IServiceManager
{
    IProjectService Project { get;}
    ITaskService Task { get; }
    IIssueService Issue {get;}
    
}
