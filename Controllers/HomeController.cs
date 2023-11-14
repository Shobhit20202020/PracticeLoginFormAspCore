using Microsoft.AspNetCore.Mvc;
using PracticeLoginFormAspCore.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace PracticeLoginFormAspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDBContext context;

        public HomeController(MyDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Login(Logindatum user)
        {

            var myUses = context.Logindata.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (myUses != null)
            {
                HttpContext.Session.SetString("UserSession", myUses.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed and Register-first";
               
            }
            return View();
        }





        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserSession")!=null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
           
            return View();
        }


        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
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