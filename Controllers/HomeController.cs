﻿using kursyonetimi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace kursyonetimi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Kullanıcı giriş yapmış ise user null olmaz ve anasayfayı açar
            //Eğer null gelmiş ise kullanıcı login sayfasına yönlenir...
            var user = HttpContext.Session.GetString("user");
            if(user == null) {
                return RedirectToAction("Giris", "Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}