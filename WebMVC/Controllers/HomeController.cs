﻿using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.DataProvider;
using System.Collections.Generic;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly MySqlAppDb Db;
        public HomeController(MySqlAppDb db)
        {
            Db = db;
        }

        public async Task<IActionResult> Index()
        {
            //UserProvider userProvider = new UserProvider(Db);
            //var user = await userProvider.GetUsersAsync();
            return View();
        }
        [HttpDelete("{userName}")]
        public IActionResult Delete(string userName)
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
