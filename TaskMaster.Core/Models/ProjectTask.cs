using MongoDB.Bson.Serialization.Attributes;
using TaskMaster.Core.Abstracts;
using TaskMaster.Core.Enums;

namespace TaskMaster.Core.Models;

public class ProjectTask : ModelBase
{
    public string ProjectId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.Medium;
    public int Duration { get; set; }
    public DateTime? StartingDate { get; set; }
    public DateTime? EndingDate => StartingDate!.Value.AddDays(Duration);
    public DateTime? FinishedDate { get; set; }

    public Enums.TaskStatus TaskStatus { get; set; } = Enums.TaskStatus.NotStarted;
    public string? StatusExplation { get; set; }


    [BsonIgnore]
    public List<Issue> Issues { get; set; } = new();

}
