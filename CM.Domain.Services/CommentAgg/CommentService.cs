using Base_Framework.Domain.Services;
using CM.Domain.Core.CommentAgg.Data;
using CM.Domain.Core.CommentAgg.DTOs;
using CM.Domain.Core.CommentAgg.Services;

namespace CM.Domain.Services.CommentAgg
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<OperationResult> Add(AddCommentDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
          await  _commentRepository.Add(command, cancellationToken);
            _commentRepository.Save();
            return operation.Succedded();
        }

        public async Task<OperationResult> Cancel(long id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (!_commentRepository.IsExist(c => c.Id == id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _commentRepository.Cancel(id, cancellationToken);
            _commentRepository.Save();
            return operation.Succedded();
        }

        public async Task<OperationResult> Confirm(long id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (!_commentRepository.IsExist(c => c.Id == id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _commentRepository.Confirm(id, cancellationToken);
            _commentRepository.Save();
            return operation.Succedded();
        }

        

      public async  Task<List<Core.CommentAgg.DTOs.CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            return await _commentRepository.Search(searchModel, cancellationToken);
        }
    }
}
