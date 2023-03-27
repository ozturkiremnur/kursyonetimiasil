using Microsoft.AspNetCore.Mvc;

namespace kursyonetimi.Components
{
	public class HeadViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
