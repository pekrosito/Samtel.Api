using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices.DTOs
{
    public class ClientDTO
    {
        public string codigoNaturalezaCliente { get; set; }

        public string codigoTipoIdent { get; set; }

        public string codigoOcupacion { get; set; }

        public string numeroIdentificacion  { get; set; }

        public DateTime fechaExpedicion { get; set; }

        public string lugarExpedicion { get; set; }

        public int identificacionCliente { get; set; }

        public string nombreCompleto { get; set; }
    }
}
