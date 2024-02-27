using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.ProjectDtos;

namespace TaskMaster.Web.Pages.Project;

public class GetProjectDetailsModel(IServiceManager manager) : PageModel
{
    public ProjectDto Project { get; set; }
    public async Task OnGet(string id)
    {
        var projects = await manager.Project.GetProjectsAsync();
        Project = projects.SingleOrDefault(x => x.Id == id)!;
    }
}
