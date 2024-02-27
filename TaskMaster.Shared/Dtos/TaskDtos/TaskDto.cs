namespace TaskMaster.Shared.Dtos.TaskDtos;

public record TaskDto(string Id, string ProjectId, string Title, string? Description, string PriorityLevel, int Duration, DateTime? StartingDate, DateTime? EndingDate, DateTime? FinishedDate, string TaskStatus, string? StatusExplation, bool IsActive);

