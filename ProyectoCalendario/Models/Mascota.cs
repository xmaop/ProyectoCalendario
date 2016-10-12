using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Models
{
    public class Mascota
    {

        public int MascotaId { get; set; }
        public string nombreMascota { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string fechaNacimientoMascota { get; set; }
        public string razaMascota { get; set; }

        public List<ListaAtencion> listaAtencion { get; set; }

    }
}