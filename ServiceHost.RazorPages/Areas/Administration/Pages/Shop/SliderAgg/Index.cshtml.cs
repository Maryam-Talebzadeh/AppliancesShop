using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SM.Domain.Core.SliderAgg.AppServices;
using SM.Domain.Core.SliderAgg.DTOs;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Shop.SliderAgg
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<SlideViewModel> Slides;

        private readonly ISlideAppService _slideAppService;

        public IndexModel(ISlideAppService slideAppService)
        {
            _slideAppService = slideAppService;
        }

        public void OnGet()
        {
            Slides = _slideAppService.GetList();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateSlideViewModel();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateSlideViewModel command)
        {
            var result = _slideAppService.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideAppService.GetDetails(id);
            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditSlideViewModel command)
        {
            var result = _slideAppService.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _slideAppService.Remove(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _slideAppService.Restore(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
