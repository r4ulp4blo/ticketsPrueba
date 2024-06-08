using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using ticketsPrueba.Models;

namespace ticketsPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //
        //Esta vista es tecnicamente la base, la que ocupara cualquier usuario que NO tenga ROL
        //
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                var datosUsuario = JsonSerializer.Deserialize<usuarios>(HttpContext.Session.GetString("user"));
                ViewBag.NombreUsuario = datosUsuario.Nombre;
                
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
