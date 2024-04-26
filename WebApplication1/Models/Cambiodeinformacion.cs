using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cambiodeinformacion
    {
        List<Persona> listaDeClientes = Program.listaDeClientes;

        public void CambioEstrato(int identificacion, int estrato)
        {

            foreach (Persona cliente in listaDeClientes)
            {
                if (cliente.Identificacion == identificacion)
                {
                    cliente.Cliente.Estrato = estrato;                   

                }
            }
        }
        public void cambiarMetadeAhorrodeEnergia(Persona cliente, int metaahorroenergia)
        {
            cliente.Cliente.Metaahorroenergia = metaahorroenergia;
        }
        public void cambiarConsumoActualdeEnergia(Persona cliente, int consumoactualenergia)
        {
            cliente.Cliente.Consumoactualenergia = consumoactualenergia;
        }
        public void cambiarPromedioConsumoAgua(Persona cliente, int promedioconsumodeagua)
        {
            cliente.Cliente.Promedioconsumodeagua = promedioconsumodeagua;
        }
        public void cambiarConsumoActualdeAgua(Persona cliente, int consumoactualagua)
        {
            cliente.Cliente.Consumoactualagua = consumoactualagua;
        }
        public void modificarClienteEnergia(int identificacion, int nuevoMetaAhorroEnergia, int nuevoConsumoActualEnergia)
        {
            
            Persona clienteAModificar = listaDeClientes.FirstOrDefault(p => p.Identificacion == identificacion);
            if (clienteAModificar != null)
            {
                
                
                clienteAModificar.Cliente.Metaahorroenergia = nuevoMetaAhorroEnergia;
                clienteAModificar.Cliente.Consumoactualenergia = nuevoConsumoActualEnergia;

                Console.WriteLine($"Información de energía del cliente con identificación {identificacion} modificada correctamente.");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún cliente con identificación {identificacion}.");
            }
        }



    }
}