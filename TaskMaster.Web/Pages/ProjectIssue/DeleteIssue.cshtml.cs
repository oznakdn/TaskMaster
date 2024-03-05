using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;

namespace TaskMaster.Web.Pages.ProjectIssue;

public class DeleteIssueModel(IServiceManager manager, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public string Id { get; set; }

    public async Task OnGet(string id)
    {
        Id = id;
        var project = await manager.Issue.GetIssueByIdAsync(id);
        TempData["projectId"] = project.ProjectId;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var project = await manager.Issue.GetIssueByIdAsync(Id);
        await manager.Issue.DeleteIssueAsync(Id);
        notyfService.Success("Issue has been deleted successfully.");
        return RedirectToPage("/ProjectIssue/GetProjectIssues", new { id = project.ProjectId });
    }
}
