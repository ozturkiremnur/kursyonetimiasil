using kursyonetimi.Models.HelperModel;
using Microsoft.AspNetCore.Mvc;

namespace kursyonetimi.ComponentManagement
{
    public class HeaderViewComponent : ViewComponent
    {    
        public async Task<IViewComponentResult> InvokeAsync(string title, string subtitle, string parentTitle)
        {
            titleModel tm = new titleModel()
            {
                title = title,
                subtitle = subtitle,
                parentTitle = parentTitle
            };
            return View(tm);
        }
    }
}
