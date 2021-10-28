using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExplorerApp.Models;

namespace ExplorerApp.Controllers
{
    public class ExplorerController : Controller
    {
        private readonly ILogger<ExplorerController> _logger;

        public ExplorerController(ILogger<ExplorerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index()
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
