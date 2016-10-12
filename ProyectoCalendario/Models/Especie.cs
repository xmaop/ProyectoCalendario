using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Models
{
    public class Especie
    {
        public int EspecieId { get; set; }
        public string nombre { get; set; }
        public List<Calendario> calendario { get; set; }
        public List<ListaAtencion> listaAtencion { get; set; }
    }
}