using Base_Framework.Domain.Core.Contracts;
using CM.Domain.Core.CommentAgg.DTOs;
using CM.Domain.Core.CommentAgg.Entities;


namespace CM.Domain.Core.CommentAgg.Data
{
   public interface ICommentRepository : IRepository<Comment>
    {
        Task Add(AddCommentDTO command, CancellationToken cancellationToken);
        Task Confirm(long id, CancellationToken cancellationToken);
        Task Cancel(long id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken);
    }
}
