using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;

namespace TaskMaster.Web.Pages
{
    public class IndexModel(IServiceManager manager) : PageModel
    {

        public int ProjectCount { get; set; }
        public int TaskCount { get; set; }
        public int IssueCount { get; set; }

        public async Task OnGetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ProjectCount = await manager.Project.ProjectCountAsync(cancellationToken);
            TaskCount = await manager.Task.TaskCountAsync(cancellationToken);
            IssueCount = await manager.Issue.IssueCountAsync(cancellationToken);
        }
    }
}
