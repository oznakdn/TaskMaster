using MongoDB.Driver;
using System.Linq.Expressions;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Core.Enums;
using TaskMaster.Core.Models;
using TaskMaster.Persistence.Manager;
using TaskMaster.Shared.Dtos.ProjectDtos;

namespace TaskMaster.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly IRepositoryManager _repository;

    public ProjectService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task CreateProjectAsync(CreateProjectDto projectDto, CancellationToken cancellationToken = default)
    {
        var project = new Project
        {
            Name = projectDto.Name,
            Repo = projectDto.Repo,
            Description = projectDto.Description,
            Story = projectDto.Story,
            Duration = projectDto.Duration,
            StartingDate = projectDto.StartingDate,
            FinishedDate = projectDto.FinishedDate,
            ProjectStatus = (ProjectStatus)projectDto.ProjectStatus,
            Comment = projectDto.Comment
        };

        await _repository.Project.CreateAsync(project);
    }

    public async Task DeleteProjectAsync(string id, CancellationToken cancellationToken = default)
    {
        await _repository.Project.DeleteAsync(id, cancellationToken);
    }

    public async Task<ProjectDto> GetProjectByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var project = await _repository.Project.GetAsync(x => x.Id == id, cancellationToken);
        return new ProjectDto(
            project.Id,
            project.IsActive,
            project.Name,
            project.Description,
            project.Story,
            project.Repo,
            project.Duration,
            project.StartingDate,
            project.EndingDate,
            project.FinishedDate,
            project.ProjectStatus.ToString(),
            project.Comment!);
    }

    public async Task<IEnumerable<ProjectDto>> GetProjectsAsync(Expression<Func<Project, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        var projects = await _repository.Project.GetAllAsync(filter, cancellationToken);


        return projects.Select(x => new ProjectDto(
            x.Id,
            x.IsActive,
            x.Name,
            x.Description,
            x.Story,
            x.Repo,
            x.Duration,
            x.StartingDate,
            x.EndingDate,
            x.FinishedDate,
            x.ProjectStatus.ToString(),
            x.Comment!)).ToList();

    }

    public async Task<int> ProjectCountAsync(CancellationToken cancellationToken = default) =>await _repository.Project.CountAsync(cancellationToken);


    public async Task UpdateProjectAsync(UpdateProjectDto projectDto, CancellationToken cancellationToken = default)
    {
        var project = new Project
        {
            Id = projectDto.Id,
            Name = projectDto.Name,
            Story = projectDto.Story,
            Repo = projectDto.Repo,
            Description = projectDto.Description,
            Duration = projectDto.Duration,
            FinishedDate = projectDto.FinishedDate,
            IsActive = projectDto.IsActive,
            StartingDate = projectDto.StartingDate,
            Comment = projectDto.Comment,
            ProjectStatus = (ProjectStatus)projectDto.ProjectStatus
        };

        await _repository.Project.UpdateAsync(project, cancellationToken);
    }


}
