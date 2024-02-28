using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Persistence.Manager;
using TaskMaster.Shared.Dtos.IssueDtos;

namespace TaskMaster.Application.Services.Implementations;

public class IssueService : IIssueService
{
    private readonly IRepositoryManager _manager;

    public IssueService(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IEnumerable<IssueDto>> GetIssuesByProjectId(string projectId, CancellationToken cancellationToken = default)
    {
        var issues = await _manager.Issue.GetAllAsync(x => x.ProjectId == projectId, cancellationToken);
        return issues.Select(x => new IssueDto(
            x.Id, 
            x.ProjectId, 
            x.Name,
            x.Description, 
            x.PriorityLevel.ToString(),
            x.StartingDate,
            x.EndingDate,
            x.FinishedDate,
            x.IssueStatus.ToString(),
            x.StatusExplation,
            x.IsActive
            )).ToList();
        
    }
}