namespace TaskMaster.Shared.Dtos.ProjectDtos;

public class UpdateProjectDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Story { get; set; }
    public int Duration { get; set; }
    public DateTime? StartingDate { get; set; }
    public DateTime? FinishedDate { get; set; }
    public StatusDto ProjectStatus { get; set; }
    public string? StatusExplation { get; set; }
    public bool IsActive { get; set; }
}

