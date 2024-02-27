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

        await _manager.Task.CreateTaskAsync(projectTask,cancellationToken);
    }

    public async Task<IEnumerable<TaskDto>> GetTasksByProjectId(string projectId, CancellationToken cancellationToken = default)
    {
        var projectTasks = await _manager.Task.GetTasksByProjectId(projectId, cancellationToken);

        return projectTasks.Select(x => new TaskDto(
            x.Id,
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
}
