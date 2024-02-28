using TaskMaster.Application.Services.Interfaces;
using TaskMaster.Core.Enums;
using TaskMaster.Core.Models;
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

    public async Task CreateIssueAsync(CreateIssueDto createIssueDto, CancellationToken cancellationToken = default)
    {
        var projectIssue = new ProjectIssue
        {
            ProjectId = createIssueDto.ProjectId,
            Description = createIssueDto.Description,
            Name = createIssueDto.Name,
            StartingDate = createIssueDto.StartingDate,
            FinishedDate = createIssueDto.FinishedDate,
            IssueStatus = (ProjectTaskStatus)createIssueDto.IssueStatus,
            PriorityLevel = (PriorityLevel)createIssueDto.PriorityLevel,
            StatusExplation = createIssueDto.StatusExplation
        };

        await _manager.Issue.CreateAsync(projectIssue, cancellationToken);

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
            x.FinishedDate,
            x.IssueStatus.ToString(),
            x.StatusExplation,
            x.IsActive
            )).ToList();

    }
}