using kursyonetimi.Models;
using kursyonetimi.Repos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursyonetimi.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Giris()
        {
            //Kullanıcı eğer giriş yapmış ise giriş ekranını göremez anasayfaya yönlenir... 
            if(HttpContext.Session.GetString("user") != null)
                return RedirectToAction("Index", "Home");
            return View();
        }
        public user loginkontrol(string username, string password)
        {
            userCTX uctx = new userCTX();
            var user = uctx.usertek("select * from user where username = @username and password = @password and isactive = 1", new { username = username, password = password });
            return user;
        }

        public JsonResult loginKontrolJson(string username, string password)
        {
            //status (success || error) ve message keywordleri olan bir tane json veri döndürmeni istiyorum....
            var kullaniciVarMi = loginkontrol(username, password);
            if (kullaniciVarMi != null)
            {
                
                //kullanıcı var ise Session oluşturuyoruz....
                var userJson = JsonConvert.SerializeObject(kullaniciVarMi);
                profileCTX pctx = new profileCTX();
                var mevcutProfil = pctx.profilTek("select * from Profile where userId = @userId and isActive = 1", new { userId = kullaniciVarMi.id });
                var profileJson = JsonConvert.SerializeObject(mevcutProfil);
                HttpContext.Session.SetString("user", userJson);
                HttpContext.Session.SetString("profil", profileJson);

                return Json(new { status = "Success", message = "Giriş Başarılı Yönleniyorsunuz" });

            }
            return Json(new { status = "Error", message = "Kullanıcı adı ya da parola yanlış!" });



        }
    }
}
