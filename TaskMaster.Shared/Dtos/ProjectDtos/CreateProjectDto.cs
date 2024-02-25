namespace TaskMaster.Shared.Dtos.ProjectDtos;

public record CreateProjectDto(string Name, string? Description, string? Story, int Duration, DateTime? StartingDate, DateTime? FinishedDate, StatusDto ProjectStatus, string? StatusExplation);

public enum StatusDto
{
    Pending, // Askida
    Overdue, // Vadesi gecmis
    NotStarted, // Henuz baslamadi
    Active, // Aktif
    Priority, // Oncelik verildi
    Canceled // Iptal edildi
}