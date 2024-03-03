using TaskMaster.Core.Abstracts;
using TaskMaster.Core.Enums;

namespace TaskMaster.Core.Models;

public class ProjectIssue : ModelBase
{
    public string ProjectId { get; set; }
    public string Summary { get; set; }
    public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.Medium;
    public DateTime? StartingDate { get; set; }
    public DateTime? FixedDate => ResolutionStatus == ResolutionStatus.Fixed ? DateTime.Now : null;
    public ResolutionStatus ResolutionStatus { get; set; } = ResolutionStatus.Unresolved;
    public string? Comment { get; set; }

}
