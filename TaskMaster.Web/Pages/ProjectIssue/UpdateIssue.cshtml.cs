using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.IssueDtos;
using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Web.Pages.ProjectIssue;

public class UpdateIssueModel(IServiceManager manager, INotyfService notyfService) : PageModel
{
    [BindProperty]
    public UpdateIssueDto UpdateIssue { get; set; } = new();
    
    public string ProjectId { get; set; }
    public async Task OnGetAsync(string id)
    {
        var issue = await manager.Issue.GetIssueByIdAsync(id);
        ProjectId = issue.ProjectId;

        UpdateIssue.Id = id;
        UpdateIssue.Summary = issue.Summary;
        UpdateIssue.PriorityLevel = (PriorityLevelDto)Enum.Parse(typeof(PriorityLevelDto), issue.PriorityLevel);
        UpdateIssue.StartingDate = issue.StartingDate;
        UpdateIssue.Comment = issue.Comment;
        UpdateIssue.IsActive = issue.IsActive;
        UpdateIssue.ResolutionStatus = (ResolutionStatusDto)Enum.Parse(typeof(ResolutionStatusDto), issue.ResolutionStatus);
    }


    public async Task<IActionResult> OnPostAsync()
    {
        var projectId = await manager.Issue.UpdateIssueAsync(UpdateIssue, default);
        notyfService.Success("Issue has been updated successfully.");
        return RedirectToPage("/ProjectIssue/GetProjectIssues", new { id = projectId });
    }
}
