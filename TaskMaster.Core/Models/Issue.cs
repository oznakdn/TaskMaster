using TaskMaster.Core.Enums;

namespace TaskMaster.Core.Models;

public class Issue
{
    public string ProjectId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.Medium;
    public DateTime? StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public DateTime? FinishedDate { get; set; }
    public Enums.ProjectTaskStatus IssueStatus { get; set; } = Enums.ProjectTaskStatus.NotStarted;
    public string? StatusExplation { get; set; }

}
