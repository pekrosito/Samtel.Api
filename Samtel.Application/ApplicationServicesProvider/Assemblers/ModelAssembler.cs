using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServicesProvider.Assemblers
{
    public class ModelAssembler
    {

        public static BigCrediPremium CreateCredit(CreditDTO credit)
        {

            return new BigCrediPremium
            {
                i_codigo_cliente = credit.CodigoCliente,
                i_mora_maxima_cliente = credit.MoraMaximaCliente,
                s_peor_calif_riesgo = credit.PeorCalifRiesgo,
                s_calif_riesgo = credit.CalifRiesgo,
                i_nro_cred_corte = int.Parse(credit.NroCredCorte),
                i_mora_max_6_mes = credit.MoraMaxMes,
                s_tipo_cliente = credit.TipoCliente,
                i_linea_credito = credit.LineaCredito
            };
        }


        public static Client CreateClient(ClientDTO client)
        {

            return new Client
            {
               s_codigo_naturaleza_cliente = client.codigoNaturalezaCliente,
               s_codigo_tipo_ident = client.codigoTipoIdent,
               i_codigo_ocupacion = client.codigoOcupacion,
               s_numero_identificacion = client.numeroIdentificacion,
               d_fecha_expedicion = client.fechaExpedicion,
               s_lugar_expedicion = client.lugarExpedicion,
               i_identificacion_cliente = client.identificacionCliente,
               s_nombre_completo = client.nombreCompleto
            };
        }


    }
}
