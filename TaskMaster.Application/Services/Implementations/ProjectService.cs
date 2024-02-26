﻿using MongoDB.Driver;
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
            Description = projectDto.Description,
            Story = projectDto.Story,
            Duration = projectDto.Duration,
            StartingDate = projectDto.StartingDate,
            FinishedDate = projectDto.FinishedDate,
            ProjectStatus = (ProjectStatus)projectDto.ProjectStatus,
            StatusExplation = projectDto.StatusExplation
        };

        await _repository.Project.CreateProjectAsync(project);
    }


    public async Task<IEnumerable<ProjectDto>> GetProjectsAsync(Expression<Func<Project, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        var projects = await _repository.Project.GetProjectsAsync(filter, cancellationToken);


        return projects.Select(x => new ProjectDto(
            x.Id,
            x.IsActive,
            x.Name,
            x.Description,
            x.Story,
            x.Duration,
            x.StartingDate,
            x.EndingDate,
            x.FinishedDate,
            x.ProjectStatus.ToString(),
            x.StatusExplation!)).ToList();

    }

    public async Task UpdateProjectAsync(UpdateProjectDto projectDto, CancellationToken cancellationToken = default)
    {
        var project = new Project
        {
            Id = projectDto.Id,
            Name = projectDto.Name,
            Story = projectDto.Story,
            Description = projectDto.Description,
            Duration = projectDto.Duration,
            FinishedDate = projectDto.FinishedDate,
            IsActive = projectDto.IsActive,
            StartingDate = projectDto.StartingDate,
            StatusExplation = projectDto.StatusExplation,
            ProjectStatus = (TaskMaster.Core.Enums.ProjectStatus)projectDto.ProjectStatus
        };

        await _repository.Project.UpdateProjectAsync(project, cancellationToken);
    }
}
