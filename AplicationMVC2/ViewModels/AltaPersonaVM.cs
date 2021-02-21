using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicationMVC2.ViewModels
{
    public class AltaPersonaVM
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Debe indicar un nombre.")]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
    }
}