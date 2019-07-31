using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Application.ApplicationServices.DTOs;

namespace Samtel.Application.ApplicationServices.DTOs
{
    public class ClientDTO
    {
        public string cod_naturaleza { get; set; }
        public string cod_tipo_dent { get; set; }
        public string cod_ocupacion { get; set; }
        public string num_identificacion { get; set; }
        public string fecha_expedicion { get; set; }
        public string lugar_expedicion { get; set; }
        public int identificacionCliente { get; set; }
        public string nombreCompleto { get; set; }

        public CompanyDTO Company { get; set; }

        public PersonDTO Person { get; set; }
    }
}
