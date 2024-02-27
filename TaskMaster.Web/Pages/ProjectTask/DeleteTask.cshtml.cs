using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;

namespace TaskMaster.Web.Pages.ProjectTask;

public class DeleteTaskModel(IServiceManager manager) : PageModel
{
    [BindProperty]
    public string Id { get; set; }
    public void OnGet(string id)
    {
        Id = id;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await manager.Task.DeleteTaskAsync(Id);
        return RedirectToPage("/Project/GetProjects");
    }
}
