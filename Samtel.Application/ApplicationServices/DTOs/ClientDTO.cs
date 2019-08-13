using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices.DTOs
{
    public class ClientDTO
    {
        public string CodNaturaleza { get; set; }
        public string CodTipoIdentificacion { get; set; }
        public string CodOcupacion { get; set; }
        public string NumIdentificacion { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public string LugarExpedicion { get; set; }
        public int IdentificacionCliente { get; set; }
        public string NombreCompleto { get; set; }
        public PersonDTO Person { get; set; }
    }
}
