using Samtel.Application.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models.Entities;

namespace Samtel.Application.ApplicationServicesProvider.Assemblers
{
    public class DTOAssembler
    {
        public static PersonDTO CreatePerson(Person person){

            return new PersonDTO
            {
                apellido = person.surname
            };
        }

        public static ClientDTO createClient(Client client)
        {

            String nombreCodigoTipo = codigoTipo(client);
            String nombreCodigoOcupacion = codigoOcupacion(client);
            String fecha = client.d_fecha_expedicion.ToString("dd/MM/yyyy");
            String Expedicion = lugarExpedicion(client);
            return new ClientDTO
            {

                codigoNaturalezaCliente = client.s_codigo_naturaleza_cliente,
                codigoOcupacion = nombreCodigoOcupacion,
                codigoTipoIdent = nombreCodigoTipo,
                numeroIdentificacion = client.s_numero_identificacion,
                fechaExpedicion = fecha,
                lugarExpedicion = Expedicion,
                identificacionCliente = client.i_identificacion_cliente,
                nombreCompleto = client.s_nombre_completo
            };
        }

        public static  List<ClientDTO> listClients(List<Client> client)
        {
            List<ClientDTO> listClients = new List<ClientDTO>();
            foreach (Client item in client)
            {
                listClients.Add(createClient(item));
            }
            return listClients;
        }
        public static String codigoTipo(Client client)
        {

            string nomenclatura = "";
            if (client.s_codigo_tipo_ident.Equals("CC"))
            {
                nomenclatura = "Cedula de Ciudadania";
            }
            if (client.s_codigo_tipo_ident.Equals("CE"))
            {
                nomenclatura = "Cedula de Extranjeria";
            }
            if (client.s_codigo_tipo_ident.Equals("NIT"))
            {
                nomenclatura = "Numero de Identificación Tributaria";
            }
            if (client.s_codigo_tipo_ident.Equals("RCN"))
            {
                nomenclatura = "Residenciado";
            }
            if (client.s_codigo_tipo_ident.Equals("TI"))
            {
                nomenclatura = "Tarjeta de Identidad";
            }
            return nomenclatura;
        }



        public static String codigoOcupacion(Client client)
        {

            string nomenclatura = "";
            if (client.i_codigo_ocupacion.Equals("PENS"))
            {
                nomenclatura = "Pensionado";
            }
            if (client.i_codigo_ocupacion.Equals("OTRA"))
            {
                nomenclatura = "Otra Ocuapción";
            }
            if (client.i_codigo_ocupacion.Equals("ASAL"))
            {
                nomenclatura = "Asalariado";
            }
            if (client.i_codigo_ocupacion.Equals("INDE"))
            {
                nomenclatura = "Independiente";
            }
            if (client.i_codigo_ocupacion.Equals("HOGA"))
            {
                nomenclatura = "Hogar";
            }
            if (client.i_codigo_ocupacion.Equals("RENT"))
            {
                nomenclatura = "Retirado";
            }
            return nomenclatura;
        }

        public static String lugarExpedicion(Client client)
        {
            String resultado;
            if (client.s_lugar_expedicion.Equals("//"))
            {
                resultado = "Sin Lugar de Expedición";
            }
            else
            {
                resultado = client.s_lugar_expedicion;
            }
            return resultado;
        }
    }

}
