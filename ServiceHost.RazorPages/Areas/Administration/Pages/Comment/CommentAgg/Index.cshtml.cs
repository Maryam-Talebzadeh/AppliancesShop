using CM.Domain.Core.CommentAgg.AppServices;
using CM.Domain.Core.CommentAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Comment.CommentAgg
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<CommentDTO> Comments;
        public SearchCommentDTO SearchModel;
        private readonly ICommentAppService _commentAppService;

        public IndexModel(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        public async Task OnGet(SearchCommentDTO searchModel, CancellationToken cancellationToken)
        {
            Comments =await  _commentAppService.Search(searchModel, cancellationToken);
        }

        public async Task<IActionResult> OnGetCancel(long id, CancellationToken cancellationToken)
        {
            var result = await _commentAppService.Cancel(id, cancellationToken);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetConfirm(long id, CancellationToken cancellationToken)
        {
            var result = await _commentAppService.Confirm(id, cancellationToken);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
