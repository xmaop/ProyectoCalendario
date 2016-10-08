using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoCalendario.Models;
namespace ProyectoCalendario.Models
{
    public class CalendarioDetalle
    {
        public IEnumerable<Calendario> Calendarios { get; set; }
        public IEnumerable<DetalleCalendario> DetalleCalendarios  { get; set; }
    }
}