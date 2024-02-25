using TaskMaster.Persistence.Repositories.Interfaces;

namespace TaskMaster.Persistence.Manager;

public class RepositoryManager : IRepositoryManager
{
    private readonly IProjectRepository _project;
    public RepositoryManager(IProjectRepository project)
    {
        _project = project;
    }

    public IProjectRepository Project => _project;
}
