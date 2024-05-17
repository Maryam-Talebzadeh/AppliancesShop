using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.RazorPages.ViewComponents
{
        public class FooterViewComponent : ViewComponent
        {
            public IViewComponentResult Invoke()
            {
                return View();
            }
        }
    
}
