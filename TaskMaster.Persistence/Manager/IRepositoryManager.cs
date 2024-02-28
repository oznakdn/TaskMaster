using TaskMaster.Persistence.Repositories.Interfaces;

namespace TaskMaster.Persistence.Manager;

public interface IRepositoryManager
{
    IProjectRepository Project { get; }
    ITaskRepository Task { get; }
    IProjectIssueRepository Issue {get;}

}
