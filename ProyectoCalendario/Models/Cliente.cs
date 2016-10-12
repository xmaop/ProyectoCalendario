using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string dniCliente { get; set; }
        public int telefonoCliente { get; set; }
        public string direccionCliente { get; set; }

        public List<ListaAtencion> listaAtencion { get; set; }

        //  public List<DetalleCalendario> detallecalendario { get; set; }
        //  public List<Mascota> mascota { get; set; }
    }
}