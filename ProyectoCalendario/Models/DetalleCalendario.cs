using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Models
{
    public class DetalleCalendario
    {
        public int DetallecalendarioId { get; set; }

        public int CalendarioId { get; set; }

        public int VacunaId { get; set; }

        public int edadmin { get; set; }

        public int edadmax { get; set; }

        public int numeroveces { get; set; }

        public string viaaplicacion { get; set; }

        public double volumen { get; set; }

        public string unidad { get; set; }

        public string efectos { get; set; }

        public virtual Calendario calendario { get; set; }
        public virtual Vacuna vacuna { get; set; }
    }
}