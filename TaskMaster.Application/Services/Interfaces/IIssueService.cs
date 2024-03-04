using TaskMaster.Shared.Dtos.IssueDtos;

namespace TaskMaster.Application.Services.Interfaces;

public interface IIssueService
{
    Task<IEnumerable<IssueDto>> GetIssuesByProjectId(string projectId, CancellationToken cancellationToken = default(CancellationToken));
    Task<IssueDto> GetIssueByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken));
    Task<int> IssueCountAsync(CancellationToken cancellationToken = default(CancellationToken));

    Task CreateIssueAsync(CreateIssueDto createIssueDto, CancellationToken cancellationToken = default(CancellationToken));
    Task<string> UpdateIssueAsync(UpdateIssueDto updateIssueDto, CancellationToken cancellationToken = default(CancellationToken));
    Task<string> UpdateIssueStatusAsync(string id, string issueStatus, string? comment, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteIssueAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

}