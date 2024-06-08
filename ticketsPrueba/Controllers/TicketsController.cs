using Microsoft.AspNetCore.Mvc;

namespace ticketsPrueba.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
