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
            if (cliente != null && cliente.Cliente != null)
            {
                cliente.Cliente.Metaahorroenergia = metaahorroenergia;
            }
            else
            {
                
            }
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


    }
}