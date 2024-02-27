using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Web.Pages.ProjectTask;

public class GetProjectTasksModel(IServiceManager manager) : PageModel
{
    public IEnumerable<TaskDto> Tasks { get; set; } = new List<TaskDto>();

    [BindProperty]
    public CreateTaskDto CreateTask { get; set; }

    [BindProperty]
    public string Id { get; set; }
    public async Task OnGetAsync(string id)
    {
        Id = id;
        Tasks = await manager.Task.GetTasksByProjectId(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        CreateTask.ProjectId = Id;
        await manager.Task.CreateTaskAsync(CreateTask, default!);
        return RedirectToPage("/ProjectTask/GetProjectTasks");
    }
}
