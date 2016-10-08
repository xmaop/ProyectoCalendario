using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Models
{
    public class Calendario
    {
        public int CalendarioId { get; set; }


        public string nombre { get; set; }

        public int EspecieId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string FI { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string FF { get; set; }
        public List<DetalleCalendario> detallecalendario { get; set; }
        public virtual Especie especie { get; set; }
    }
}