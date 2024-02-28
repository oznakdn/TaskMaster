using TaskMaster.Shared.Dtos.IssueDtos;

namespace TaskMaster.Application.Services.Interfaces;

public interface IIssueService
{
    Task<IEnumerable<IssueDto>>GetIssuesByProjectId(string projectId, CancellationToken cancellationToken = default(CancellationToken));
}