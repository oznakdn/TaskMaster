using TaskMaster.Core.Enums;

namespace TaskMaster.Core.Models;

public class Issue
{
    public string TaskId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.Medium;
    public DateTime? StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public DateTime? FinishedDate { get; set; }
    public Enums.TaskStatus IssueStatus { get; set; } = Enums.TaskStatus.NotStarted;
    public string? StatusExplation { get; set; }

}
