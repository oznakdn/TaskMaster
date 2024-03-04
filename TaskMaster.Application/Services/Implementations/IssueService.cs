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

    public async Task<string> UpdateIssueStatusAsync(string id, string issueStatus, string? comment, CancellationToken cancellationToken = default)
    {
        var issue = await _manager.Issue.GetAsync(x => x.Id == id);

        issue.Comment = string.IsNullOrWhiteSpace(comment) ? issue.Comment : comment;
        
        switch (issueStatus)
        {
            case "Unresolved": issue.ResolutionStatus = ResolutionStatus.Unresolved; break;
            case "Fixed": issue.ResolutionStatus = ResolutionStatus.Fixed; break;
        }
        await _manager.Issue.UpdateAsync(issue, cancellationToken);
        return issue.ProjectId;
    }
}