using Base_Framework.Domain.Services;
using CM.Domain.Core.CommentAgg.DTOs;

namespace CM.Domain.Core.CommentAgg.Services
{
    public interface ICommentService
    {
        Task<OperationResult> Add(AddCommentDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Confirm(long id, CancellationToken cancellationToken);
        Task<OperationResult> Cancel(long id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken);
    }
}
