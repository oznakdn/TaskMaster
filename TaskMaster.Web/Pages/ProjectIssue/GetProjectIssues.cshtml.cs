using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.IssueDtos;

namespace TaskMaster.Web.Pages.ProjectIssue;

public class GetProjectIssues(IServiceManager manager) : PageModel
{
    public IEnumerable<IssueDto> Issues { get; set; } = new List<IssueDto>();

    [BindProperty]
    public CreateIssueDto CreateIssue { get; set; }
    public string ProjectName { get; set; }

    public async Task OnGetAsync(string id)
    {
        TempData["projectId"] = id;
        var project = await manager.Project.GetProjectByIdAsync(id);
        ProjectName = project.Name;
        Issues = await manager.Issue.GetIssuesByProjectId(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        CreateIssue.ProjectId = TempData["projectId"]!.ToString()!;
        await manager.Issue.CreateIssueAsync(CreateIssue, default!);
        return RedirectToPage("/ProjectIssue/GetProjectIssues", new { id = TempData["projectId"] });
    }

}