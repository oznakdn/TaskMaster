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

    public async Task<int> TaskCountAsync(CancellationToken cancellationToken = default) => await _manager.Task.CountAsync(cancellationToken);

    public async Task UpdateTaskAsync(UpdateTaskDto updateTaskDto, CancellationToken cancellationToken = default)
    {
        var task = await _manager.Task.GetAsync(x => x.Id == updateTaskDto.Id, cancellationToken);

        task.Title = updateTaskDto.Title;
        task.Description = updateTaskDto.Description;
        task.Duration = updateTaskDto.Duration;
        task.FinishedDate = updateTaskDto.FinishedDate;
        task.StartingDate = updateTaskDto.StartingDate;
        task.PriorityLevel = (PriorityLevel)updateTaskDto.PriorityLevel;
        task.TaskStatus =(ProjectTaskStatus)updateTaskDto.TaskStatus;
        task.StatusExplation = updateTaskDto.StatusExplation;
        task.IsActive = updateTaskDto.IsActive;

        await _manager.Task.UpdateAsync(task, cancellationToken);
    }

    public async Task<string> UpdateTaskStatusAsync(string id, string taskStatus, CancellationToken cancellationToken = default)
    {
        var task = await _manager.Task.GetAsync(x => x.Id == id);

        switch (taskStatus)
        {
            case "ToDo": task.TaskStatus = ProjectTaskStatus.ToDo; break;
            case "Progress": task.TaskStatus = ProjectTaskStatus.Progress; break;
            case "Review": task.TaskStatus = ProjectTaskStatus.Review; break;
            case "Done": task.TaskStatus = ProjectTaskStatus.Done; break;
        }
        await _manager.Task.UpdateAsync(task, cancellationToken);
        return task.ProjectId;
    }


}
