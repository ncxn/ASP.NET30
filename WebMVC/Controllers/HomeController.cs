using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.DataProvider;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebMVC.Controllers
{

    public class HomeController : Controller
    {
        
        private readonly MySqlAppDb Db;
        public HomeController(MySqlAppDb db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
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
