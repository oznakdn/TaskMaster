﻿using TaskMaster.Core.Abstracts;
using TaskMaster.Core.Enums;

namespace TaskMaster.Core.Models;

public class ProjectIssue : ModelBase
{
    public string ProjectId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.Medium;
    public DateTime? StartingDate { get; set; }
    public DateTime? FinishedDate { get; set; }
    public ProjectTaskStatus IssueStatus { get; set; } = Enums.ProjectTaskStatus.ToDo;
    public string? StatusExplation { get; set; }

}
