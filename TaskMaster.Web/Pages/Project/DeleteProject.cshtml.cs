using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;

namespace TaskMaster.Web.Pages.Project;

public class DeleteProjectModel(IServiceManager manager) : PageModel
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
        return RedirectToPage("/Project/GetProjects");
    }
}
