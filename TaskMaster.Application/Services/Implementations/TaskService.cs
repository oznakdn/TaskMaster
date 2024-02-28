using System.Linq.Expressions;
using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Core.Enums;
using TaskMaster.Core.Models;
using TaskMaster.Persistence.Manager;
using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Application.Services.Implementations;

public class TaskService : ITaskService
{
    private readonly IRepositoryManager _manager;

    public TaskService(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task CreateTaskAsync(CreateTaskDto createTaskDto, CancellationToken cancellationToken = default)
    {
        var projectTask = new ProjectTask
        {
            ProjectId = createTaskDto.ProjectId,
            Title = createTaskDto.Title,
            Description = createTaskDto.Description,
            Duration = createTaskDto.Duration,
            FinishedDate = createTaskDto.FinishedDate,
            StartingDate = createTaskDto.StartingDate,
            PriorityLevel = (PriorityLevel)createTaskDto.PriorityLevel,
            TaskStatus = (ProjectTaskStatus)createTaskDto.TaskStatus,
            StatusExplation = createTaskDto.StatusExplation
        };

        await _manager.Task.CreateAsync(projectTask, cancellationToken);
    }

    public async Task DeleteTaskAsync(string id, CancellationToken cancellationToken = default)
    {
        await _manager.Task.DeleteAsync(id, cancellationToken);
    }

    public async Task<TaskDto> GetTaskById(string id, CancellationToken cancellationToken = default)
    {
        var task = await _manager.Task.GetAsync(x => x.Id == id, cancellationToken);
        return new TaskDto(
            task.Id, 
            task.ProjectId, 
            task.Title, 
            task.Description, 
            task.PriorityLevel.ToString(), 
            task.Duration, 
            task.StartingDate, 
            task.EndingDate, 
            task.FinishedDate, 
            task.TaskStatus.ToString(), 
            task.StatusExplation, 
            task.IsActive);
    }

    public async Task<IEnumerable<TaskDto>> GetTasksAsync(Expression<Func<ProjectTask, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        var tasks = await _manager.Task.GetAllAsync(filter, cancellationToken);


        return tasks.Select(x => new TaskDto(
            x.Id,
            x.ProjectId,
            x.Title,
            x.Description,
            x.PriorityLevel.ToString(),
            x.Duration,
            x.StartingDate,
            x.EndingDate,
            x.FinishedDate,
            x.TaskStatus.ToString(),
            x.StatusExplation,
            x.IsActive
            )).ToList();
    }

    public async Task<IEnumerable<TaskDto>> GetTasksByProjectId(string projectId, CancellationToken cancellationToken = default)
    {
        var projectTasks = await _manager.Task.GetAllAsync(filter: x => x.ProjectId == projectId, cancellationToken);

        return projectTasks.Select(x => new TaskDto(
            x.Id,
            x.ProjectId,
            x.Title,
            x.Description,
            x.PriorityLevel.ToString(),
            x.Duration,
            x.StartingDate,
            x.EndingDate,
            x.FinishedDate,
            x.TaskStatus.ToString(),
            x.StatusExplation,
            x.IsActive
            )).ToList();
    }

    public async Task UpdateTaskAsync(UpdateTaskDto updateTaskDto, CancellationToken cancellationToken = default)
    {
        var projectTask = new ProjectTask
        {
            Id = updateTaskDto.Id,
            ProjectId = updateTaskDto.ProjectId ?? default!,
            Title = updateTaskDto.Title ?? default!,
            Description = updateTaskDto.Description ?? default!,
            Duration = updateTaskDto.Duration,
            IsActive = updateTaskDto.IsActive,
            FinishedDate = updateTaskDto.FinishedDate ?? default!,
            StartingDate = updateTaskDto.StartingDate ?? default!,
            PriorityLevel = (PriorityLevel)updateTaskDto.PriorityLevel,
            TaskStatus = (ProjectTaskStatus)updateTaskDto.TaskStatus,
            StatusExplation = updateTaskDto.StatusExplation ?? default!
        };

        await _manager.Task.UpdateAsync(projectTask, cancellationToken);
    }
}
