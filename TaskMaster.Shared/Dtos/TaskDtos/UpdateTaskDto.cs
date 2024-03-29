﻿namespace TaskMaster.Shared.Dtos.TaskDtos;

public class UpdateTaskDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public PriorityLevelDto PriorityLevel { get; set; }
    public int Duration { get; set; }
    public DateTime? StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public DateTime? FinishedDate { get; set; }
    public TaskStatusDto TaskStatus { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }

}
