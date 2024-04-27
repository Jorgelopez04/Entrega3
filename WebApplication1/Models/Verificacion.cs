using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Verificacion
    {
        List<Persona> listaDeClientes = Program.listaDeClientes;
        public bool verificarExistenciaDeIdentidad(int identificacion)
        {
            foreach (Persona persona in listaDeClientes)
            {
                if (persona.Identificacion == identificacion)
                {
                    return true;
                }

            }
            return false;
        }
        public bool verificarsielEstratoeselMismo(int id, int estratoactual)
        {
            foreach (Persona cliente in listaDeClientes)
            {
                if (cliente.Identificacion == id && cliente.Cliente.Estrato == estratoactual)
                {
                    return true;
                }
                return false;
            }
            return false;

        }
        public bool verificarsilaMetadeahorrodeEnergiaeslaMisma(int id, int metaahorroactual)
        {
            foreach (Persona cliente in listaDeClientes)
            {
                if (cliente.Identificacion == id && cliente.Cliente.Metaahorroenergia==metaahorroactual)
                {
                    return true;
                }
                return false;
            }
            return false;

        }
        public bool verificarsielconsumoactualdeEnergiaeselMismo(int id, int consumoactualenergia)
        {
            foreach (Persona cliente in listaDeClientes)
            {
                if (cliente.Identificacion == id && cliente.Cliente.Consumoactualenergia == consumoactualenergia)
                {
                    return true;
                }
                return false;
            }
            return false;

        }
        public bool verificarsielpromedioactualdeConsumodeAguaeselMismo(int id, int promedioconsumoagua)
        {
            foreach (Persona cliente in listaDeClientes)
            {
                if (cliente.Identificacion == id && cliente.Cliente.Promedioconsumodeagua == promedioconsumoagua)
                {
                    return true;
                }
                return false;
            }
            return false;

        }
        public bool verificarsielConsumodeAguaeselMismo(int id, int consumoagua)
        {
            foreach (Persona cliente in listaDeClientes)
            {
                if (cliente.Identificacion == id && cliente.Cliente.Consumoactualagua == consumoagua)
                {
                    return true;
                }
                return false;
            }
            return false;

        }
    }
}