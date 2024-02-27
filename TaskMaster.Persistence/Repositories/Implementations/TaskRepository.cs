using TaskMaster.Core.Models;
using TaskMaster.Persistence.Data.Context;
using TaskMaster.Persistence.Data.Options;
using TaskMaster.Persistence.Repositories.Interfaces;

namespace TaskMaster.Persistence.Repositories.Implementations;

public class TaskRepository : MongoContext<ProjectTask>, ITaskRepository
{
    public TaskRepository(IMongoOption option) : base(option)
    {
    }

    
}

