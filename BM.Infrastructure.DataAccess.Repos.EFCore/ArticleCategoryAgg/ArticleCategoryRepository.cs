using Base_Framework.Infrastructure.DataAccess;
using BM.Domain.Core.ArticleCategoryAgg.Data;
using BM.Domain.Core.ArticleCategoryAgg.DTOs;
using BM.Domain.Core.ArticleCategoryAgg.Entities;
using BM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Base_Framework.Domain.General;

namespace BM.Infrastructure.DataAccess.Repos.EFCore.ArticleCategoryAgg
{
    public class ArticleCategoryRepository : BaseRepository_EFCore<ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _context;
        public ArticleCategoryRepository(BlogContext context) : base(context) 
        {
            _context = context;
        }

        public async Task Create(CreateArticleCategoryDTO command, CancellationToken cancellationToken)
        {
            var articleCategory = new ArticleCategory(command.Name, command.PictureName, command.PictureAlt, command.PictureTitle,
                command.Description, command.ShowOrder, command.Slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);

            _context.ArticleCategories.Add(articleCategory);
        }

        public async Task Edit(EditArticleCategoryDTO command, CancellationToken cancellationToken)
        {
            var articleCategory = Get(command.Id);
            articleCategory.Edit(command.Name, command.PictureName, command.PictureAlt, command.PictureTitle, command.Description, command.ShowOrder
                , command.Slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);
        }

        public async Task<List<ArticleCategoryDTO>> GetArticleCategories(CancellationToken cancellationToken)
        {
            return _context.ArticleCategories.Select(x => new ArticleCategoryDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public async Task<EditArticleCategoryDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return _context.ArticleCategories.Select(x =>
            new EditArticleCategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PictureName = x.Picture
            }).FirstOrDefault();
        }

        public async Task<string> GetSlugBy(long id, CancellationToken cancellationToken)
        {
            return _context.ArticleCategories.Select(x => new { x.Id, x.Slug })
                .FirstOrDefault(x => x.Id == id).Slug;
        }

        public async Task<List<ArticleCategoryDTO>> Search(SearchArticleCategoryDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.ArticleCategories
                .Select(x => new ArticleCategoryDTO
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Picture = x.Picture,
                    ShowOrder = x.ShowOrder,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ArticlesCount = x.Articles.Count()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.ShowOrder).ToList();
        }
    }
}
