using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Persona
    {

        int identificacion;
        string nombre;
        string apellidos;
        DateTime fechaNacimiento;
        Cliente cliente;

        public Persona(int identificacion, string nombre, string apellidos, DateTime fechaNacimiento, Cliente cliente)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.cliente = cliente;
        }

        public int Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }

    }
}

    
