using Samtel.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Domain.Models.Entities
{
    public class Client: Entity
    {
        public string s_codigo_naturaleza_cliente { get; set; }
        public string s_codigo_tipo_ident { get; set; }
        public string i_codigo_ocupacion { get; set; }
        public string s_numero_identificacion { get; set; }
        public string d_fecha_expedicion { get; set; }
        public string s_lugar_expedicion { get; set; }
        public string i_identificacion_cliente { get; set; }
    }
}
