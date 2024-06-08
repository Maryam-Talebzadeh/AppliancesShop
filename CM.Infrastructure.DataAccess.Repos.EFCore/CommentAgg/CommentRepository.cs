using Base_Framework.Infrastructure.DataAccess;
using CM.Domain.Core.CommentAgg.Data;
using CM.Domain.Core.CommentAgg.DTOs;
using CM.Domain.Core.CommentAgg.Entities;
using CM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Base_Framework.Domain.General;

namespace CM.Infrastructure.DataAccess.Repos.EFCore.CommentAgg
{
    public class CommentRepository : BaseRepository_EFCore<Comment>, ICommentRepository
    {
        private readonly CommentContext _context;

        public CommentRepository(CommentContext context) : base(context)
        {
            _context = context;
        }

        public async Task Add(AddCommentDTO command, CancellationToken cancellationToken)
        {
            var comment = new Comment(command.Name, command.Email, command.Website, command.Message, command.OwnerRecordId, command.Type, command.ParentId);
            _context.Add(comment);
        }

        public async Task Cancel(long id, CancellationToken cancellationToken)
        {
            var comment = Get(id);
            comment.Cancel();
        }

        public async Task Confirm(long id, CancellationToken cancellationToken)
        {
            var comment = Get(id);
            comment.Confirm();
        }

        public async Task<List<CommentDTO>> Search(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Comments
                .Select(x => new CommentDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Website = x.Website,
                    Message = x.Message,
                    OwnerRecordId = x.OwnerRecordId,
                    Type = x.Type,
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    CommentDate = x.CreationDate.ToFarsi()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
