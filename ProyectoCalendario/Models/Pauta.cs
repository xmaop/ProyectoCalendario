using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Models
{
    public class Pauta
    {
        public int PautaId { get; set; }

        public int vacunaId { get; set; }

        public int numeroveces { get; set; }

        public string tipotiempo { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        public int TI { get; set; }
        public string PI { get; set; }
        [Required]
        //[DataType(DataType.Date)]
        public int TF { get; set; }
        public string PF { get; set; }
        public virtual Vacuna vacuna { get; set; }
    }
}