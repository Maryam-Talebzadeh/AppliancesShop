using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.RazorPages.ViewComponents
{
        public class FooterViewComponent : ViewComponent
        {
            public async Task<IViewComponentResult> InvokeAsync()
            {
                return View();
            }
        }
    
}
