using MongoDB.Bson.Serialization.Attributes;
using TaskMaster.Core.Abstracts;
using TaskMaster.Core.Enums;

namespace TaskMaster.Core.Models;

public class Project : ModelBase
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Story { get; set; }

    public int Duration { get; set; }
    public DateTime? StartingDate { get; set; }
    public DateTime? EndingDate => StartingDate!.Value.AddDays(Duration);
    public DateTime? FinishedDate { get; set; }

    public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.NotStarted;
    public string? StatusExplation { get; set; }

    [BsonIgnore]
    public List<ProjectTask> Tasks { get; set; } = new();

}
