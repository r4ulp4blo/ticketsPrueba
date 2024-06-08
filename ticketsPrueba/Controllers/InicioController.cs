using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using ticketsPrueba.Models;

namespace ticketsPrueba.Controllers
{
    public class InicioController : Controller
    {
        private readonly ticketsContext _ticketsContext;
        public InicioController(ticketsContext ticketsContext)
        {
            _ticketsContext = ticketsContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult ValidarUsuario(credenciales credenciales)
        {
            usuarios? usuario = (from e in _ticketsContext.usuarios
                                where 
                                e.Nombre == credenciales.usuario && 
                                e.Contra == credenciales.clave
                                select e).FirstOrDefault();

            if (usuario == null) 
            {
                ViewBag.Mensaje = "Credenciales incorrectas!!";
                return View("Index");
            }

            //string rolUsuario = JsonSerializer.Serialize(ObtenerRolUsuario(usuario.Id_usuario));
            string rolUsuario = ObtenerRolUsuario(usuario.Id_usuario);


            string datosUsuario = JsonSerializer.Serialize(usuario);

            HttpContext.Session.SetString("user", datosUsuario);

            HttpContext.Session.SetString("rol", rolUsuario);

            // Redirigir a la acción correspondiente según el rol
            if (rolUsuario == "Cliente")
            {
                return RedirectToAction("Index", "Clientes");
            }
            else if (rolUsuario == "Administrador")
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (rolUsuario == "Tecnico")
            {
                return RedirectToAction("Index", "Tecnicos");
            }
            else
            {
                // Manejar otros roles o situaciones según sea necesario
                return RedirectToAction("Index", "Home");
            }



        }


        private string ObtenerRolUsuario(int idUsuario)
        {
            // Verificar si el usuario es un técnico
            tecnicos tecnico = _ticketsContext.tecnicos.FirstOrDefault(t => t.Id_usuario == idUsuario);
            if (tecnico != null)
            {
                // Verificar el tipo de rol del técnico
                if (tecnico.Rol == "Administrador")
                {
                    return "Administrador";
                }
                else if (tecnico.Rol == "Tecnico")
                {
                    return "Tecnico";
                }
                else
                {
                    return "Rol no definido"; // Manejar cualquier otro caso según tus necesidades
                }
            }

            // Verificar si el usuario es un cliente
            clientes cliente = _ticketsContext.clientes.FirstOrDefault(c => c.Id_usuario == idUsuario);
            if (cliente != null)
            {
                return "Cliente";
            }

            // Si no es ni técnico ni cliente, manejarlo según tus necesidades
            return "Usuario sin rol asignado";
        }

    }
}
