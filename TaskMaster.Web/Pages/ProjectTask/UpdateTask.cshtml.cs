using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Web.Pages.ProjectTask;

public class UpdateTaskModel(IServiceManager manager) : PageModel
{
    [BindProperty]
    public UpdateTaskDto UpdateTask { get; set; } = new();
    public string ProjectId { get; set; }
    public async Task OnGetAsync(string id)
    {
        var task = await manager.Task.GetTaskById(id);
        ProjectId = task.ProjectId;
        TempData["projectId"] = ProjectId;
        UpdateTask.Id = id;
        UpdateTask.Title = task!.Title;
        UpdateTask.Description = task!.Description;
        UpdateTask.Duration = task!.Duration;
        UpdateTask.StartingDate = task!.StartingDate;
        UpdateTask.FinishedDate = task!.FinishedDate;
        UpdateTask.TaskStatus = (TaskStatusDto)Enum.Parse(typeof(TaskStatusDto), task!.TaskStatus);
        UpdateTask.PriorityLevel = (PriorityLevelDto)Enum.Parse(typeof(PriorityLevelDto), task!.PriorityLevel);
        UpdateTask.Comment = task!.Comment;
        UpdateTask.IsActive = task.IsActive;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        
        await manager.Task.UpdateTaskAsync(UpdateTask, default!);
        return RedirectToPage("/ProjectTask/GetProjectTasks", new { id = TempData["projectId"] });
    }
}
