using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Application.Manager;
using TaskMaster.Shared.Dtos.TaskDtos;

namespace TaskMaster.Web.Pages.ProjectTask;

public class GetTasksModel(IServiceManager manager) : PageModel
{

    public IEnumerable<TaskDto>Tasks { get; set; } = new List<TaskDto>();
    public async Task OnGetAsync()
    {
        Tasks = await manager.Task.GetTasksAsync(default);
    }
}
