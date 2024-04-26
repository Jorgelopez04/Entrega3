using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Program
    {
        public static Program instanciaUnica;
        public Cambiodeinformacion cambiarInfo = new Cambiodeinformacion();
        public Verificacion verificarInfo = new Verificacion();
        public static Program ObtenerInstancia()
        {
            if (instanciaUnica == null)
            {
                instanciaUnica = new Program();
            }

            return instanciaUnica;
        }

        public static List<Persona> listaDeClientes = new List<Persona>();
        public List<Persona> ListaDeClientes { get => listaDeClientes; set => listaDeClientes = value; }
        public Cambiodeinformacion CambiarInfo { get => cambiarInfo; set => cambiarInfo = value; }
        public Verificacion VerificarInfo { get => verificarInfo; set => verificarInfo = value; }
        public Persona obtenerClientePorId(int id)
        {
            foreach (Persona cliente in listaDeClientes)
            {
                if (cliente.Identificacion == id)
                {
                    return cliente;
                }
            }

            return null;
        }

        public void ingresarCliente(Persona nuevoCliente)
        {
            listaDeClientes.Add(nuevoCliente);
        }

        public void eliminarClientePorId(int id)
        {
            
            Persona clienteAEliminar = listaDeClientes.FirstOrDefault(p => p.Identificacion == id);
            if (clienteAEliminar != null)
            {
                listaDeClientes.Remove(clienteAEliminar);
                Console.WriteLine($"Cliente con identificación {id} eliminado correctamente.");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún cliente con identificación {id}.");
            }
        }
    }
}
