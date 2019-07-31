using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices.DTOs
{
    public class ClientDTO
    {
        public string codigo_naturaleza_cliente {get;set;}
        public string codigo_tipo_ident {get; set;}
        public string codigo_ocupacion {get;set;}
        public string numero_identificacion {get;set;}
        public DateTime fecha_expedicionn {get;set;}
        public string lugar_expedicion {get;set;}
        public int identificacion_cliente {get;set;}
        public string nombre_completo { get; set; }
    }
}
