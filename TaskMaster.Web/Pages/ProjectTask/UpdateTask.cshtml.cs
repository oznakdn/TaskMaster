using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Web.Pages.ProjectTask;

public class UpdateTaskModel(IServiceManager manager) : PageModel
{
    [BindProperty]
    public UpdateTaskDto UpdateTask { get; set; } = new();

    [BindProperty]
    public string ProjectId { get; set; }
    public async Task OnGetAsync(string id)
    {
        UpdateTask.Id = id;
        var tasks = await manager.Task.GetTasksAsync(filter: null!, default!);
        var task = tasks.SingleOrDefault(x => x.Id == id);
        ProjectId = task!.ProjectId;

        UpdateTask.Title = task!.Title;
        UpdateTask.ProjectId = ProjectId;
        UpdateTask.Description = task!.Description;
        UpdateTask.Duration = task!.Duration;
        UpdateTask.StartingDate = task!.StartingDate;
        UpdateTask.FinishedDate = task!.FinishedDate;
        UpdateTask.TaskStatus = (TaskStatusDto)Enum.Parse(typeof(TaskStatusDto), task!.TaskStatus);
        UpdateTask.PriorityLevel = (PriorityLevelDto)Enum.Parse(typeof(PriorityLevelDto), task!.PriorityLevel);
        UpdateTask.StatusExplation = task!.StatusExplation;
        UpdateTask.IsActive = task.IsActive;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        UpdateTask.ProjectId = ProjectId;
        await manager.Task.UpdateTaskAsync(UpdateTask, default!);
        return RedirectToPage("/ProjectTask/GetProjectTasks",new { id = ProjectId });
    }
}
