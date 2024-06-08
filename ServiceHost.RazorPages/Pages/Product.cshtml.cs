using CM.Domain.Core.CommentAgg.AppServices;
using CM.Domain.Core.CommentAgg.DTOs;
using DM.Infrastructure.DataAccess.Repos.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;

namespace ServiceHost.RazorPages.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery _productQuery;
        private readonly ICommentAppService _commentAppService;

        public ProductModel(IProductQuery productQuery, ICommentAppService commentAppService)
        {
            _productQuery = productQuery;
            _commentAppService = commentAppService;
        }

        public async Task OnGet(string id, CancellationToken cancellationToken)
        {
            Product = await _productQuery.GetDetails(id, cancellationToken);
        }

        public async Task<IActionResult> OnPost(AddCommentDTO command, string productSlug, CancellationToken cancellationToken)
        {
            command.Type = CommentTypes.Product;
            var result =await _commentAppService.Add(command, cancellationToken);
            return RedirectToPage("/Product", new { Id = productSlug });
        }
    }
}
