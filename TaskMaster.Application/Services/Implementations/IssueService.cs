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
            Summary = createIssueDto.Summary,
            StartingDate = createIssueDto.StartingDate,
            PriorityLevel = (PriorityLevel)createIssueDto.PriorityLevel,
            ResolutionStatus = (ResolutionStatus)createIssueDto.ResolutionStatus,
            Comment = createIssueDto.Comment
        };

        await _manager.Issue.CreateAsync(projectIssue, cancellationToken);

    }

    public async Task<IEnumerable<IssueDto>> GetIssuesByProjectId(string projectId, CancellationToken cancellationToken = default)
    {
        var issues = await _manager.Issue.GetAllAsync(x => x.ProjectId == projectId, cancellationToken);
        return issues.Select(x => new IssueDto(
            x.Id,
            x.ProjectId,
            x.Summary,
            x.PriorityLevel.ToString(),
            x.StartingDate,
            x.FixedDate,
            x.ResolutionStatus.ToString(),
            x.Comment,
            x.IsActive
            )).ToList();

    }
}