using CM.Domain.Core.CommentAgg.AppServices;
using CM.Domain.Core.CommentAgg.DTOs;
using CM.Domain.Core.CommentAgg.Services;

namespace CM.Domain.AppServices.CommentAgg
{
    public class CommentAppService : ICommentAppService
    {

        private readonly ICommentService _commentService;

        public CommentAppService(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult> Add(AddCommentDTO command, CancellationToken cancellationToken)
        {
            return await _commentService.Add(command, cancellationToken);
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult> Cancel(long id, CancellationToken cancellationToken)
        {
            return await _commentService.Cancel(id, cancellationToken);
        }

        public async Task<global::Base_Framework.Domain.Services.OperationResult> Confirm(long id, CancellationToken cancellationToken)
        {
            return await _commentService.Confirm(id, cancellationToken);
        }

        public async Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            return await _commentService.Search(searchModel, cancellationToken);
        }
    }
}
