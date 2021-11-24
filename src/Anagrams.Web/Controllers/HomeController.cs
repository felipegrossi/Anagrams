using Anagrams.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Anagrams.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string search = "")
        {
            if (string.IsNullOrEmpty(search))
                return View(new List<string>());

            return View(new List<string> { search });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}