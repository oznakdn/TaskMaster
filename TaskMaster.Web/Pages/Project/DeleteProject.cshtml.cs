using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;

namespace TaskMaster.Web.Pages.Project;

public class DeleteProjectModel(IServiceManager manager, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public string Id { get; set; }
    public void OnGet(string id)
    {
        Id = id;
    }

    public async Task<IActionResult>OnPostAsync()
    {
        await manager.Project.DeleteProjectAsync(Id);
        await manager.Task.DeleteAllTaskByProjectIdAsync(Id);
        await manager.Issue.DeleteAllIssueByProjectIdAsync(Id);
        notyfService.Success("Project has been deleted successfully.");
        return RedirectToPage("/Project/GetProjects");
    }
}
