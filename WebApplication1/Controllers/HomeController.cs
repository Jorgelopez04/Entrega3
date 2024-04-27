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


            Persona persona = new Persona(identificacion, nombre, apellidos, fechaNacimiento, cliente);


            program.ingresarCliente(persona);
            return View(persona);


        }

       
        public ActionResult verificarParacambioMeta()
        {
            int id;
            id = Convert.ToInt32(Request.Form["idcambioMetaahorro"]);

            if (program.VerificarInfo.verificarExistenciaDeIdentidad(id) == false)
            {
                TempData["NotificacionActualizarCosto"] = "El paciente no se encuentra en el sistema";
            }
            else
            {
                string idMomentaneo = Convert.ToString(id);
                TempData["idMomentaneoCosto"] = idMomentaneo;
                TempData.Keep("idMomentaneoCosto");
                return RedirectToAction("mostrarActualizarCosto");

            }
            return RedirectToAction("actualizarCosto");
        }
        public ActionResult mostrarcambioMetaahorro()
        {
            Persona paciente = program.obtenerClientePorId(id);
            if (paciente != null)
            {
                return View(paciente);
            }
            else
            {
                TempData["Notificacion"] = "El paciente no se encuentra en el sistema";
                return RedirectToAction("cambioMetaahorro");
            }
        }
        [HttpPost]
        public ActionResult CambioMetaahorro(int idcambioMetaahorro, int nuevaMeta)
        {
            Persona paciente = program.obtenerClientePorId(idcambioMetaahorro);
            if (paciente != null)
            {
                program.CambiarInfo.cambiarMetadeAhorrodeEnergia(paciente, nuevaMeta);
                TempData["Notificacion"] = "Meta de ahorro de energía actualizada correctamente.";
            }
            else
            {
                TempData["Notificacion"] = "El paciente no se encuentra en el sistema.";
            }

            return RedirectToAction("cambioMetaahorro");
        }

        public ActionResult verificarParacambioConsumoEnergia()
        {
            int id;
            id = Convert.ToInt32(Request.Form["idcambioConsumoAgua"]);

            if (program.VerificarInfo.verificarExistenciaDeIdentidad(id) == false)
            {
                TempData["NotificacionActualizarCosto"] = "El paciente no se encuentra en el sistema";
            }
            else
            {
                string idMomentaneo = Convert.ToString(id);
                TempData["idMomentaneoCosto"] = idMomentaneo;
                TempData.Keep("idMomentaneoCosto");
                return RedirectToAction("MostrarcambioConsumoEnergia");

            }
            return RedirectToAction("actualizarCosto");
        }
        public ActionResult mostrarcambioConsumoEnergia()
        {
            string dato = (string)TempData["idMomentaneoCosto"];
            TempData.Keep("idMomentaneoCosto");
            int datoEntero = Convert.ToInt32(dato);
            Persona paciente = program.obtenerClientePorId(datoEntero);
            ViewBag.Notificacion = TempData["cambioConsumoActualdeEnergiaRealizado"];
            return View(paciente);
        }
        public ActionResult cambioConsumoEnergia()
        {
            string dato = (string)TempData["idMomentaneoCosto"];
            int datoEntero = Convert.ToInt32(dato);
            int consumoactualenergia = Convert.ToInt32(Request.Form["nuevoConsumo"]);
            Persona persona = program.obtenerClientePorId(datoEntero);
            program.CambiarInfo.cambiarConsumoActualdeEnergia(persona, consumoactualenergia);

            TempData["cambioCostoTratamientosRealizado"] = "El costo de los tratamientos del paciente se ha actualizado con éxito";
            return RedirectToAction("MostrarcambioConsumoEnergia");
        }
















    }
}




