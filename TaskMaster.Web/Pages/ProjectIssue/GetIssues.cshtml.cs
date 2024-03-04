using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.IssueDtos;

namespace TaskMaster.Web.Pages.ProjectIssue;

public class GetIssuesModel(IServiceManager manager) : PageModel
{
    public IEnumerable<IssueDto> Issues { get; set; } = new List<IssueDto>();
    public async Task OnGetAsync(CancellationToken cancellation = default(CancellationToken))
    {
        Issues = await manager.Issue.GetIssuessAsync(cancellation);
    }
}
