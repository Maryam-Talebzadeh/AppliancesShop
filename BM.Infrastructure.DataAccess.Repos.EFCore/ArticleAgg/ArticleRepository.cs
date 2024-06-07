using Base_Framework.Domain.General;
using Base_Framework.Infrastructure.DataAccess;
using BM.Domain.Core.ArticleAgg.Data;
using BM.Domain.Core.ArticleAgg.DTOs;
using BM.Domain.Core.ArticleAgg.Entities;
using BM.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace BM.Infrastructure.DataAccess.Repos.EFCore.ArticleAgg
{
    public class ArticleRepository : BaseRepository_EFCore<Article>, IArticleRepository
    {
        private readonly BlogContext _context;
        public ArticleRepository(BlogContext context) : base(context)
        {
            _context = context;
        }
        public async Task Create(CreateArticleDTO command, CancellationToken cancellationToken)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Description, command.PictureName, command.PictureAlt, command.PictureTitle,
                command.PublishDate.ToGregorianDateTime(), command.Slug, command.Keywords, command.MetaDescription, command.CanonicalAddress, command.CategoryId);

            _context.Articles.Add(article);
        }

        public async Task Edit(EditArticleDTO command, CancellationToken cancellationToken)
        {
            var article = Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Description, command.PictureName, command.PictureAlt, command.PictureTitle,
                command.PublishDate.ToGregorianDateTime(), command.Slug, command.Keywords, command.MetaDescription, command.CanonicalAddress, command.CategoryId);
        }

        public async Task<EditArticleDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return _context.Articles.Select(x =>
            new EditArticleDTO
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Title = x.Title
            }).FirstOrDefault(a => a.Id == id);
        }


        public async Task<List<ArticleDTO>> Search(SearchArticleDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Articles.Select(x => new ArticleDTO
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Category = x.Category.Name,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + " ...",
                Title = x.Title
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
