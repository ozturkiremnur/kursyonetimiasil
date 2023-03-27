using Microsoft.AspNetCore.Mvc;

namespace kursyonetimi.Controllers
{
    public class OgrenciController : Controller
    {
        //Öğrenci Listesi Görüntüleme için view Return eden Sayfa gelecek...
        public IActionResult ogrenciListesi()
        {
            return View();
        }

        //Öğrenci Ekleyen Sayfa
        public IActionResult ogrenciEkle()
        {
            return View();
        }
    }
}
