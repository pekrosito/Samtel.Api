using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices.DTOs
{
   public class ClientDTO
    {
        public string CodigoNaturalezaCliente { get; set; }
        public string CodigoTipoIdentidad { get; set; }
        public string CodigoOcupacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string FechaExpedicion { get; set; }
        public string LugarExpedicion { get; set; }
        public string IdentificacionCliente { get; set; }
        
    }
}
