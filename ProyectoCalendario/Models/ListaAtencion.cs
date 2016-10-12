using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Models
{
    public class ListaAtencion
    {
        public int ListaAtencionId { get; set; }
        public int ClienteId { get; set; }
        public int MascotaId { get; set; }
        public int EspecieId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string fechaAtencion { get; set; }
        public string horaAtencion { get; set; }

        public int estado { get; set; }

        public virtual Cliente cliente { get; set; }
        public virtual Mascota mascota { get; set; }
        public virtual Especie especie { get; set; }



    }
}