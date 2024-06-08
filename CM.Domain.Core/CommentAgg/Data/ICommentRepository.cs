using CM.Domain.Core.CommentAgg.DTOs;


namespace CM.Domain.Core.CommentAgg.Data
{
   public interface ICommentRepository
    {
        Task Add(AddCommentDTO command, CancellationToken cancellationToken);
        Task Confirm(long id, CancellationToken cancellationToken);
        Task Cancel(long id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken);
    }
}
