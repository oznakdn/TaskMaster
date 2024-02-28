using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Shared.Dtos.IssueDtos;

public record IssueDto(string Id, string ProjectId,string Name, string? Description, string PriorityLevel, DateTime? StartingDate, DateTime? EndingDate, DateTime? FinishedDate, string IssueStatus, string? StatusExplation, bool IsActive);