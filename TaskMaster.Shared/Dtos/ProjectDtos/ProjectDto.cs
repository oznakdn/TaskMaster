namespace TaskMaster.Shared.Dtos.ProjectDtos;

public record ProjectDto(string Id, bool IsActive, string Name, string? Description, string? Story, int Duration, string? StartingDate, string? EndingDate, string? FinishedDate, string Status, string StatusExplation);

