using Microsoft.AspNetCore.Mvc;

namespace kursyonetimi.ComponentManagement
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
