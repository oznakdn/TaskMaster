using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.ProjectDtos;
using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Web.Pages
{
    public class IndexModel(IServiceManager manager, INotyfService notyfService) : PageModel
    {
        [BindProperty]
        public CreateProjectDto CreateProject { get; set; }

        [BindProperty]
        public CreateTaskDto CreateTask { get; set; }

        public SelectList ProjectList { get; set; }

        public int ProjectCount { get; set; }
        public int TaskCount { get; set; }
        public int IssueCount { get; set; }

        public async Task OnGetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ProjectCount = await manager.Project.ProjectCountAsync(cancellationToken);
            TaskCount = await manager.Task.TaskCountAsync(cancellationToken);
            IssueCount = await manager.Issue.IssueCountAsync(cancellationToken);
            var projects = await manager.Project.GetProjectsAsync();
            ProjectList = new SelectList(projects, "Id", "Name");
        }

        public async Task<IActionResult> OnPostCreateProject()
        {
            await manager.Project.CreateProjectAsync(CreateProject);
            notyfService.Success("Project has been created successfully.");
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostCreateTask()
        {
            await manager.Task.CreateTaskAsync(CreateTask);
            notyfService.Success("Task has been created successfully.");
            return RedirectToPage("/Index");
        }
    }
}
