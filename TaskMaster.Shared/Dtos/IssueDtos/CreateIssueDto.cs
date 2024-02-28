using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Shared.Dtos.IssueDtos;

public class CreateIssueDto
{
    public string ProjectId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public PriorityLevelDto PriorityLevel { get; set; }
    public DateTime? StartingDate { get; set; }
    public DateTime? FinishedDate { get; set; }
    public TaskStatusDto IssueStatus { get; set; }
    public string? StatusExplation { get; set; }
}
