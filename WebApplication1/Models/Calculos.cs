using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Calculos
    {

        static List<Cliente> clientes = new List<Cliente>();
        static List<Persona> personas = new List<Persona>();


        static int costoEnergia = 850;
        static int costoAgua = 4600;
        static int costoExcesoAgua = 9200;
        public static void CalcularValorAPagar(int identificacion)
        {
            // Busca al cliente por identificación
            Cliente cliente = clientes.FirstOrDefault(c => c.Identificacion == identificacion);

            if (cliente != null)
            {
                double valorEnergia = cliente.Consumoactualenergia * costoEnergia;
                double valorTotalEnergia = valorEnergia - CalcularDescuentoEnergia(cliente);
                double valorTotalAgua = CalcularValorAgua(cliente);
                double valorTotal = valorTotalEnergia + valorTotalAgua;

                Console.WriteLine($"Valor a pagar por servicios de energía y agua: {valorTotal}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado. Verifique la identificación ingresada.");
            }
        }


        public static int CalcularDescuentoEnergia(Cliente cliente)
        {
            int descuento = cliente.Metaahorroenergia - cliente.Consumoactualenergia;
            if (descuento > 0)
            {
                return descuento * costoEnergia;
            }
            else
            {
                return 0;
            }
        }

        public static double CalcularValorAgua(Cliente cliente)
        {
            double valorAgua = cliente.Consumoactualagua * costoAgua;
            double valorExceso = cliente.Consumoactualagua > cliente.Promedioconsumodeagua ?
                (cliente.Consumoactualagua - cliente.Promedioconsumodeagua) * costoExcesoAgua : 0;
            return valorAgua + valorExceso;
        }

        // Otros métodos de cálculo y análisis pueden ser adaptados de manera similar
    }
}
