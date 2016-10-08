using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Models
{
    public class Vacuna
    {
        public int VacunaId { get; set; }

        public string nombre { get; set; }

        public List<DetalleCalendario> detallecalendario { get; set; }
        public List<Pauta> pauta { get; set; }
    }
}