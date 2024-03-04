using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Shared.Dtos.IssueDtos;

public class UpdateIssueDto
{
    public string Id { get; set; }
    public string Summary { get; set; }
    public PriorityLevelDto PriorityLevel { get; set; }
    public DateTime? StartingDate { get; set; }
    public ResolutionStatusDto ResolutionStatus { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }

}
