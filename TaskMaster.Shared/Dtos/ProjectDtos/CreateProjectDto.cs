namespace TaskMaster.Shared.Dtos.ProjectDtos;

public record CreateProjectDto(string Name, string? Description, string? Story, string? Repo, int Duration, DateTime? StartingDate, DateTime? FinishedDate, StatusDto ProjectStatus, string? Comment);

public enum StatusDto
{
    NotStarted,
    Active,
    Finished,
    Canceled,
}