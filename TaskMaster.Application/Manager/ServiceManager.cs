using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Core.Models;
using TaskMaster.Persistence.Data.Context;

namespace TaskMaster.Application.Manager;

public class ServiceManager : IServiceManager
{
    private readonly IProjectService _project;
    public ServiceManager(IProjectService project)
    {
        _project = project;
    }

    public IProjectService Project => _project;

}
