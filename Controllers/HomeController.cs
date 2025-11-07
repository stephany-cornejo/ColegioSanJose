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
                           Alumno = new Alumno { Nombre = t.Alumno.Nombre + " " + t.Alumno.Apellido},
                           Materia = new Materium { NombreMateria = t.Materia.NombreMateria },
                           NotaFinal = t.NotaFinal,
                           Observaciones = t.Observaciones
                       }).ToList();

            }
            return View(off);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(NuevoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ColegioSanJoseContext db = new ColegioSanJoseContext())
                    {
                        var viewnew = new Expediente();

                        viewnew.Alumno.Nombre = model.Alumno.Nombre;
                        viewnew.Alumno.Apellido = model.Alumno.Apellido;
                        viewnew.Alumno.Grado = model.Alumno.Grado;
                        viewnew.Alumno.FechaNacimiento = model.Alumno.FechaNacimiento;
                        viewnew.Materia.NombreMateria = model.Materia.NombreMateria;
                        viewnew.Materia.Docente = model.Materia.Docente;
                        viewnew.NotaFinal = model.NotaFinal;
                        viewnew.Observaciones = model.Observaciones;


                        db.Expedientes.Add(viewnew);
                        db.SaveChanges();
                    }
                    return Redirect("/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Editar(int id)
        {
            Expediente model = new Expediente();

            using (ColegioSanJoseContext db = new ColegioSanJoseContext())
            {
                var oTabla = db.Expedientes.Find(id);
                model.ExtpedienteId = oTabla.ExtpedienteId;
                model.Alumno.Nombre = oTabla.Alumno.Nombre;
                model.Alumno.Apellido = oTabla.Alumno.Apellido;
                model.Alumno.Grado = oTabla.Alumno.Grado;
                model.Alumno.FechaNacimiento = oTabla.Alumno.FechaNacimiento;
                model.Materia.NombreMateria = oTabla.Materia.NombreMateria;
                model.Materia.Docente = oTabla.Materia.Docente;
                model.NotaFinal = oTabla.NotaFinal;
                model.Observaciones = oTabla.Observaciones;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Actualizar(nuevoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ColegioSanJoseContext db = new ColegioSanJoseContext())
                    {
                        var viewnew = new Expediente();

                        viewnew.ExtpedienteId = model.ExtpedienteId;
                        viewnew.Alumno.Nombre = model.Alumno.Nombre;
                        viewnew.Alumno.Apellido = model.Alumno.Apellido;
                        viewnew.Alumno.Grado = model.Alumno.Grado;
                        viewnew.Alumno.FechaNacimiento = model.Alumno.FechaNacimiento;
                        viewnew.Materia.NombreMateria = model.Materia.NombreMateria;
                        viewnew.Materia.Docente = model.Materia.Docente;
                        viewnew.NotaFinal = model.NotaFinal;
                        viewnew.Observaciones = model.Observaciones;

                        db.Entry(viewnew).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("/Home/");
                }

                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int d)
        {
            Expediente model = new Expediente();

            using (ColegioSanJoseContext db = new ColegioSanJoseContext())
            {
                try
                {
                    var oTabla = db.Expedientes.Find(d);
                    db.Expedientes.Remove(oTabla);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return Redirect("/Home/");
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
