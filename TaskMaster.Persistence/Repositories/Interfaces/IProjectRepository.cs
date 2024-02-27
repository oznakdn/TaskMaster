using TaskMaster.Core.Models;
using TaskMaster.Persistence.Data.Context;

namespace TaskMaster.Persistence.Repositories.Interfaces;

public interface IProjectRepository : IMongoContext<Project>
{
    
}
