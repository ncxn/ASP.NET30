using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.DataProvider;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly MySqlAppDb DB;
        public HomeController(MySqlAppDb db)
        {
            DB = db;
        }

        public async Task<IActionResult> Index()
        {
            using (var userProvider = new UserProvidercs(DB))
            {
                
                var user = await userProvider.GetUsersAsync();
                return View(user);
            }
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
