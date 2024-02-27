using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Application.Services.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetTasksByProjectId(string projectId, CancellationToken cancellationToken = default(CancellationToken));
    Task CreateTaskAsync(CreateTaskDto createTaskDto, CancellationToken cancellationToken = default);

}
