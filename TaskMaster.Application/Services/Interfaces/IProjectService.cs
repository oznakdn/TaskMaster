using System.Linq.Expressions;
using TaskMaster.Core.Models;
using TaskMaster.Shared.Dtos.ProjectDtos;

namespace TaskMaster.Application.Services.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetProjectsAsync(Expression<Func<Project, bool>> filter = null, CancellationToken cancellationToken = default(CancellationToken));
    Task CreateProjectAsync(CreateProjectDto projectDto, CancellationToken cancellationToken = default(CancellationToken));

}
