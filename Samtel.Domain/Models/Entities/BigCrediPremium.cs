using Samtel.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Domain.Models.Entities
{
    public class BigCrediPremium :Entity
    {
        public int i_codigo_cliente { get; set; }
        public int i_mora_maxima_cliente { get; set; }
        public string s_peor_calif_riesgo { get; set; }
        public string s_calif_riesgo { get; set; }
        public int i_nro_cred_corte { get; set; }
        public int i_mora_max_6_mes { get; set; }
        public string s_tipo_cliente { get; set; }
        public string i_linea_credito { get; set; }
    }
}
