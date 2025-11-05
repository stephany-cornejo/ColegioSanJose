using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SanJoseEstudiantes.Models;
using SanJoseEstudiantes.Models.DB; 
using SanJoseEstudiantes.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SanJoseEstudiantes.Controllers
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
