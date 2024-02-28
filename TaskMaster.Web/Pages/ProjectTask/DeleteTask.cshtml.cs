using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;

namespace TaskMaster.Web.Pages.ProjectTask;

public class DeleteTaskModel(IServiceManager manager) : PageModel
{
    [BindProperty]
    public string Id { get; set; }

    public async Task OnGet(string id)
    {
        var task = await manager.Task.GetTaskById(id);
        TempData["projectId"] = task.ProjectId;
        Id = id;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await manager.Task.DeleteTaskAsync(Id);
        return RedirectToPage("/ProjectTask/GetProjectTasks",new { id = TempData["projectId"]});
    }
}
