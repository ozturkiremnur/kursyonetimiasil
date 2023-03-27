using Microsoft.AspNetCore.Mvc;

namespace kursyonetimi.ComponentManagement
{
	public class AsideViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
