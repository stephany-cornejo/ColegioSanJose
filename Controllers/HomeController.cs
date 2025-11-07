using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SanJoseEstudiantes.Models;
using SanJoseEstudiantes.Models.DB; 

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
            List<Expediente> off = new List<Expediente>();
            using (var bd = new Models.DB.ColegioSanJoseContext())
            {
                off = (from t in bd.Expedientes
                       select new Expediente
                       
                       {

                            ExtpedienteId = t.ExtpedienteId,
                            Alumno = t.Alumno,
                            Materia = t.Materia,
                            NotaFinal = t.NotaFinal,
                            Observaciones = t.Observaciones
                            
                       }).ToList();

            }
            return View(off);
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
