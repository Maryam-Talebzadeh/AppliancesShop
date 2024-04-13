using Microsoft.AspNetCore.Mvc;
using SM.Domain.Core.SliderAgg.AppServices;

namespace ServiceHost.RazorPages.ViewComponents
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ISlideAppService _slideAppService;

        public SlideViewComponent(ISlideAppService slideAppService)
        {
            _slideAppService = slideAppService;
        }

        public IViewComponentResult Invoke()
        {
            var slides = _slideAppService.GetList();
            return View(slides);
        }
    }
}
