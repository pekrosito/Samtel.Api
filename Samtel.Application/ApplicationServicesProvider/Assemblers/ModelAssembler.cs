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
        public static Client CreateClient(ClientDTO clientRequest)
        {

            return new Client
            {
                s_codigo_naturaleza_cliente = clientRequest.CodNaturaleza,
                s_codigo_tipo_ident = clientRequest.CodTipoIdentificacion,
                i_codigo_ocupacion = clientRequest.CodOcupacion,
                s_numero_identificacion = clientRequest.NumIdentificacion,
                d_fecha_expedicion = clientRequest.Fechaexpedicion,
                s_lugar_expedicion = clientRequest.LugarExpedicion,
                i_identificacion_cliente = clientRequest.IdentificacionCliente,
                s_nombre_completo = clientRequest.NombreCompleto

            };
        }

        public static Client editClient(int id, ClientDTO clientRequest)
        {
            return new Client
            {
                s_codigo_naturaleza_cliente = clientRequest.CodNaturaleza,
                s_codigo_tipo_ident = clientRequest.CodTipoIdentificacion,
                i_codigo_ocupacion = clientRequest.CodOcupacion,
                s_numero_identificacion = clientRequest.NumIdentificacion,
                d_fecha_expedicion = clientRequest.Fechaexpedicion,
                s_lugar_expedicion = clientRequest.LugarExpedicion,
                i_identificacion_cliente = id,
                s_nombre_completo = clientRequest.NombreCompleto

            };
        }
    }
}
