using System.Linq.Expressions;
using TaskMaster.Core.Models;
using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Application.Services.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetTasksByProjectId(string projectId, CancellationToken cancellationToken = default(CancellationToken));
    Task<TaskDto> GetTaskById(string id, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<TaskDto>> GetTasksAsync(Expression<Func<ProjectTask, bool>> filter = null, CancellationToken cancellationToken = default(CancellationToken));

    Task CreateTaskAsync(CreateTaskDto createTaskDto, CancellationToken cancellationToken = default);
    Task UpdateTaskAsync(UpdateTaskDto updateTaskDto, CancellationToken cancellationToken = default(CancellationToken));

    Task<string> UpdateTaskStatusAsync(string id, string taskStatus, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteTaskAsync(string id, CancellationToken cancellationToken = default(CancellationToken));
}
