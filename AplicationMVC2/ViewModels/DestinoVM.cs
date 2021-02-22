using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicationMVC2.ViewModels
{
    public class DestinoVM
    {
        public Guid Id { get; set; }
        public string Destino { get; set; }
        public Guid IdPersona { get; set; }
        public DateTime FechaPresentacion { get; set; }
    }
}