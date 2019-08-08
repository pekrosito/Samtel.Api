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
        public static PersonDTO CreatePerson(Person person)
        {

            return new PersonDTO
            {
                PrimerApellido = person.surname
            };
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

        public static ClientDTO createCliente(Client client)
        {
            ClientDTO clientDTO = new ClientDTO();
            String nombreCodigoTipo = codigoTipo(client);
            String nombreCodigoOcupacion = codigoOcupacion(client);
            String fecha = client.d_fecha_expedicion.ToString("dd/MM/yyyy");
            String Expedicion = lugarExpedicion(client);

            clientDTO.codigoNaturalezaCliente = client.s_codigo_naturaleza_cliente;
            clientDTO.codigoOcupacion = nombreCodigoOcupacion;
            clientDTO.codigoTipoIdent = nombreCodigoTipo;
            clientDTO.numeroIdentificacion = client.s_numero_identificacion;
            clientDTO.fechaExpedicion = fecha;
            clientDTO.lugarExpedicion = Expedicion;
            clientDTO.identificacionCliente = client.i_identificacion_cliente;
            clientDTO.nombreCompleto = client.s_nombre_completo;

            int count = client.s_nombre_completo.Split(' ').Count();
            var completeName = client.s_nombre_completo.Split(' ');

            if (client.s_codigo_tipo_ident.Equals("CC"))
            {
                int a = 0;
                string hola = a > 0 ? "buenas" : "malas"; 
                clientDTO.Person = new PersonDTO
                {
                    PrimerNombre = count > 0 ? completeName[0] : "",
                    SegundoNombre = count > 1 ? completeName[1] : "",
                    PrimerApellido = count > 2 ? completeName[2] : "",
                    SegundoApellido = count > 3 ? completeName[3] : ""
                };
            }
            else
            {
                clientDTO.Company = new CompanyDTO
                {
                    Nit = client.s_numero_identificacion,
                    NombreEmpresa = client.s_nombre_completo
                };
            }


            return clientDTO;

        }


        public static List<ClientDTO> listClients(List<Client> client)
        {
            List<ClientDTO> clients = new List<ClientDTO>();
            foreach (Client item in client)
            {

                clients.Add(createCliente(item));
            }
            return clients;
        }
    }
}
