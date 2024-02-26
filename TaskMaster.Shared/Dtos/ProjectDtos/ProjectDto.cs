namespace TaskMaster.Shared.Dtos.ProjectDtos;

public record ProjectDto(string Id, bool IsActive, string Name, string? Description, string? Story, int Duration, DateTime? StartingDate, DateTime? EndingDate, DateTime? FinishedDate, string Status, string StatusExplation);

