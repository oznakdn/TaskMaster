using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.ProjectDtos;

namespace TaskMaster.Web.Pages.Project;

public class GetProjectsModel(IServiceManager manager) : PageModel
{
    public IEnumerable<ProjectDto> Projects { get; set; } = new List<ProjectDto>();

    [BindProperty]
    public CreateProjectDto CreateProject { get; set; }

    public async Task OnGetAsync()
    {
        Projects = await manager.Project.GetProjectsAsync(x => x.IsActive);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await manager.Project.CreateProjectAsync(CreateProject, default!);
        return RedirectToPage("/Project/GetProjects");
    }

}
