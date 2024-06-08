using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using ticketsPrueba.Models;

namespace ticketsPrueba.Controllers
{
    public class TecnicosController : Controller
    {

        private readonly ILogger<TecnicosController> _logger;
        public TecnicosController(ILogger<TecnicosController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                var datosUsuario = JsonSerializer.Deserialize<usuarios>(HttpContext.Session.GetString("user"));
                ViewBag.NombreUsuario = datosUsuario.Nombre;
                // No es necesario ya que con esto pasaria el rol a la vista (lo cual ya hago desde la vista asignada al rol)
                //var rolUsuario = JsonSerializer.Deserialize<tecnicos>(HttpContext.Session.GetString("user"));
                //ViewBag.Rol = rolUsuario.Rol;

            }
            else
            {
                ViewBag.NombreUsuario = "Guest"; // Asignacion un valor por defecto si no hay usuario en sesión
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
