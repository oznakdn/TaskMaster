using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Shared.Dtos.IssueDtos;

public record IssueDto(string Id, string ProjectId, string Summary, string PriorityLevel, DateTime? StartingDate, DateTime? FixedDate,string ResolutionStatus, string? Comment, bool IsActive);