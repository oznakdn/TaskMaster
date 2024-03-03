using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Shared.Dtos.IssueDtos;

public class CreateIssueDto
{
    public string ProjectId { get; set; }
    public string Summary { get; set; }
    public PriorityLevelDto PriorityLevel { get; set; }
    public DateTime? StartingDate { get; set; }
    public ResolutionStatusDto ResolutionStatus { get; set; }
    public string? Comment { get; set; }
}
