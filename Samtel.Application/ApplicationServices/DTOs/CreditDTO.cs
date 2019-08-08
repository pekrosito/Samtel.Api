using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices.DTOs
{
    public class CreditDTO
    {
        public int codigoCliente { get; set; }
        public int moraMaximaCliente { get; set; }
        public string peorCalificacionRiesgo { get; set; }
        public string calificacionRiesgo { get; set; }
        public int numeroCreditoCorte { get; set; }
        public int moraMaxima6Meses { get; set; }
        public string tipoCliente { get; set; }
        public string lineaCredito { get; set; }
    }
}
