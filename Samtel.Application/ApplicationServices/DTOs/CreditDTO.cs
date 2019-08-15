using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices.DTOs
{
    public class CreditDTO
    {
        public int CodigoCliente { get; set; }

        public int MoraMaximaCliente { get; set; }
 
        public string PeorCalifRiesgo { get; set; }
        public string CalifRiesgo { get; set; }
        public string NroCredCorte { get; set; }

        public int MoraMaxMes { get; set; }
        public string TipoCliente { get; set; } 
        public string LineaCredito { get; set; }
 
    }
}
