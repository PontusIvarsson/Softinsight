using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Queries;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IBlogQueries _blogQueries;
        public HomeController(IBlogQueries blogQueries)
        {
            _blogQueries = blogQueries;
        }

        public async Task<IActionResult> Index(string searchTag)
        {
            var a = await _blogQueries.GetBlogsContainingTag(searchTag);
            return View( a);
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
