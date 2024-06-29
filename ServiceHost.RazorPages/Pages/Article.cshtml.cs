using CM.Domain.Core.CommentAgg.AppServices;
using CM.Domain.Core.CommentAgg.DTOs;
using DM.Infrastructure.DataAccess.Repos.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;

namespace ServiceHost.RazorPages.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article;
        public List<ArticleQueryModel> LatestArticles;
        public List<ArticleCategoryQueryModel> ArticleCategories;
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly ICommentAppService _commentAppService;
        public string Message { get; set; }
        [BindProperty]
        public string Id { get; set; }

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentAppService commentAppService)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
            _commentAppService = commentAppService;
        }

        public async Task OnGet(string id,CancellationToken cancellationToken)
        {
            Id = id;
            Article = await _articleQuery.GetArticleDetails(id, cancellationToken);
            LatestArticles = await _articleQuery.LatestArticles(cancellationToken);
            ArticleCategories = await _articleCategoryQuery.GetArticleCategories(cancellationToken);
        }

        public async Task<IActionResult> OnPost(AddCommentDTO command, string articleSlug, CancellationToken cancellationToken)
        {
            command.Type = CommentTypes.Article;
            var result =await  _commentAppService.Add(command, cancellationToken);
            Article = await _articleQuery.GetArticleDetails(Id, cancellationToken);
            LatestArticles = await _articleQuery.LatestArticles(cancellationToken);
            ArticleCategories = await _articleCategoryQuery.GetArticleCategories(cancellationToken);
            Message = result.Message;
            return Page();
        }

    }
}
