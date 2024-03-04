using TaskMaster.Shared.Dtos.IssueDtos;

namespace TaskMaster.Application.Services.Interfaces;

public interface IIssueService
{
    Task<IEnumerable<IssueDto>> GetIssuesByProjectId(string projectId, CancellationToken cancellationToken = default(CancellationToken));
    Task CreateIssueAsync(CreateIssueDto createIssueDto, CancellationToken cancellationToken = default(CancellationToken));
    Task<string> UpdateIssueStatusAsync(string id, string issueStatus, string? comment, CancellationToken cancellationToken = default(CancellationToken));

}