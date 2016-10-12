using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Models
{
    public class ServicioClinico
    {
        public int ServicioClinicoId { get; set; }
        public int ListaAtencionId { get; set; }
        public int CalendarioId { get; set; }
        public int detalleCalendarioId { get; set; }
        public int pautasId { get; set; }
        [DataType(DataType.Date)]
        public string FF { get; set; }

    }
}