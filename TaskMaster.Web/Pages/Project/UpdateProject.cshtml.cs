using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.ProjectDtos;

namespace TaskMaster.Web.Pages.Project;

public class UpdateProjectModel(IServiceManager manager , INotyfService notyfService) : PageModel
{
    [BindProperty]
    public UpdateProjectDto UpdateProject { get; set; } = new();

    public async Task OnGetAsync(string id)
    {
        UpdateProject.Id = id;
        var projects = await manager.Project.GetProjectsAsync(filter: null!, default!);
        var project = projects.SingleOrDefault(x => x.Id == id);

        UpdateProject.Name = project!.Name;
        UpdateProject.Description = project!.Description;
        UpdateProject.Story = project!.Story;
        UpdateProject.Repo = project!.Repo;
        UpdateProject.Duration = project!.Duration;
        UpdateProject.StartingDate = project!.StartingDate;
        UpdateProject.FinishedDate = project!.FinishedDate;
        UpdateProject.ProjectStatus = (StatusDto)Enum.Parse(typeof(StatusDto), project!.Status);
        UpdateProject.Comment = project!.Comment;
        UpdateProject.IsActive = project.IsActive;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await manager.Project.UpdateProjectAsync(UpdateProject, default!);
        notyfService.Success("Project has been updated successfully.");
        return RedirectToPage("/Project/GetProjects");
    }
}
