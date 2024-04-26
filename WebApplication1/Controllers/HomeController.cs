using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Program program = Program.ObtenerInstancia();
        public ActionResult MenuPrincipal()
        {

            return View();
        }
        public ActionResult registro()
        {
            ViewBag.Notificacion = TempData["PacienteYaRegistrado"];
            return View();
        }
        public ActionResult estadisticas()
        {
            if (program.ListaDeClientes.Count > 0)
            {
                return View(program);
            }
            else
            {
                return RedirectToAction("RegistroObligatorio");
            }

        }
        public ActionResult registroObligatorio()
        {
            return View();
        }

        public ActionResult verificarParaEstrato()
        {
            int identificacion;
            int estrato;
            identificacion = Convert.ToInt32(Request.Form["idcambioEstrato"]);
            estrato = Convert.ToInt32(Request.Form["varcambioEstrato"]);

            if (!program.VerificarInfo.verificarExistenciaDeIdentidad(identificacion))
            {
                TempData["Notificacion"] = "El usuario no se encuentra en el sistema";
            }
            
            else if (program.verificarInfo.verificarsielEstratoeselMismo(identificacion, estrato))
            {
                TempData["Notificacion"] = "El paciente ya se encuentra en este estrato";
            }
            else
            {
                program.CambiarInfo.CambioEstrato(identificacion, estrato);
                string idMomentaneo = Convert.ToString(identificacion);
                TempData["idcambioEstrato"] = idMomentaneo;
                TempData.Keep("idcambioEstrato");
                return RedirectToAction("MostrarcambioEstrato");
            }

            return RedirectToAction("cambioEstrato");


        }
        public ActionResult cambioEstrato()
        {

            ViewBag.Notificacion = TempData["Notificacion"];
            return View();
        }
        public ActionResult mostrarRegistro()
        {

            int identificacion;
            string nombre;
            string apellidos;
            DateTime fechaNacimiento;
            int estrato;
            int metaahorroenergia;
            int consumoactualenergia;
            int promedioconsumodeagua;
            int consumoactualagua;
            

            identificacion = Convert.ToInt32(Request.Form["identificacion"]);
            nombre = Convert.ToString(Request.Form["nombre"]);
            apellidos = Convert.ToString(Request.Form["apellidos"]);
            fechaNacimiento = Convert.ToDateTime(Request.Form["fechaNacimiento"]);
            estrato = Convert.ToInt32(Request.Form["estrato"]);
            metaahorroenergia = Convert.ToInt32(Request.Form["metaahorroenergia"]);
            consumoactualenergia = Convert.ToInt32(Request.Form["consumoactualenergia"]);
            promedioconsumodeagua = Convert.ToInt32(Request.Form["promedioconsumodeagua"]);
            consumoactualagua = Convert.ToInt32(Request.Form["consumoactualagua"]);


            if (program.VerificarInfo.verificarExistenciaDeIdentidad(identificacion))
            {
                TempData["PacienteYaRegistrado"] = "El paciente identificado con el numero " + identificacion + " ya se encuentra en el sistema";
                return RedirectToAction("registro");
            }
            Cliente cliente = new Cliente(identificacion, estrato, metaahorroenergia, consumoactualenergia, promedioconsumodeagua, consumoactualagua);
            

            Persona persona = new Persona(identificacion, nombre, apellidos, fechaNacimiento,cliente);


            program.ingresarCliente(persona);
            return View(persona);


        }
        public ActionResult modificarClienteEnergia()
        {
            ViewBag.Notificacion = TempData["NotificacionRegimeChange"];
            return View();
        }
        public ActionResult verificarParaActualizarEnergia()
        {
            
            int idCliente = Convert.ToInt32(Request.Form["identificacion"]);

            // Verificar si el cliente existe en el sistema
            if (!program.VerificarInfo.verificarExistenciaDeIdentidad(idCliente))
            {
                // Si el cliente no se encuentra, establecer un mensaje de notificación y redirigir a la página correspondiente
                TempData["NotificacionActualizarEnergia"] = "El cliente no se encuentra en el sistema";
                return RedirectToAction("mostrarActualizarEnergia");
            }
            else
            {
                // Si el cliente existe, guardar temporalmente su ID y redirigir a la página para actualizar la información de energía
                TempData["IdClienteActualizarEnergia"] = idCliente.ToString();
                TempData.Keep("IdClienteActualizarEnergia");
                return RedirectToAction("mostrarActualizarEnergia");
            }
        }


    }
}