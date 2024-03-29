using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;

namespace TaskMaster.Web.Pages.ProjectTask;

public class DeleteTaskModel(IServiceManager manager, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public string Id { get; set; }

    public async Task OnGet(string id)
    {
        Id = id;
        var project = await manager.Task.GetTaskById(id);
        TempData["projectId"] = project.ProjectId;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var project = await manager.Task.GetTaskById(Id);
        await manager.Task.DeleteTaskAsync(Id);
        notyfService.Success("Task has been deleted successfully.");
        return RedirectToPage("/ProjectTask/GetProjectTasks", new { id = project.ProjectId });
    }
}
