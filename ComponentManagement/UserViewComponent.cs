using kursyonetimi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kursyonetimi.ComponentManagement
{
    public class UserViewComponent :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userJson = HttpContext.Session.GetString("user");
            var userModel = JsonConvert.DeserializeObject<user>(userJson);

            return View(userModel);
        }
    }
}
