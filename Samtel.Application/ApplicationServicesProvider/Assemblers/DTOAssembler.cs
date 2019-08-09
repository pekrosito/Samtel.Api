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
        public static ExampleDTO CreatePerson2(Person person)
        {

            return new ExampleDTO
            {
                name = person.name,
                surname = person.surname,                
                identification = person.identification,

            };
        }
        public static PersonDTO CreatePerson(Person person)
        {

            return new PersonDTO
            {
                apellido = person.surname
            };
        }
        public static IEnumerable<ExampleDTO> CreatePersons2(IEnumerable<Person> person)
        {
            List<ExampleDTO> personList = new List<ExampleDTO>();
            foreach (Person element in person)
            {
                personList.Add(CreatePerson2(element));
            }
            return personList;
        }
        public static List<PersonDTO> CreatePersons(List<Person> person)
        {
            List<PersonDTO> personList = new List<PersonDTO>();
            foreach (Person element in person)
            {
                personList.Add(CreatePerson(element));
            }
            return personList;
        }
        public static IEnumerable<ClientDTO> CreateClients(IEnumerable<Client> client)
        {
            List<ClientDTO> clientList = new List<ClientDTO>();
            foreach (Client element in client)
            {
                clientList.Add(CreateClients2(element));
            }
            return clientList;
        }
        public static ClientDTO CreateClients2(Client client)
        {
                ClientDTO clientDTO = new ClientDTO();
                clientDTO.CodNaturaleza = client.s_codigo_naturaleza_cliente;
                clientDTO.CodTipoIdentificacion = client.s_codigo_tipo_ident;
                // clientDTO.CodTipoIdentificacion = codigoTipoIdent(client);
                clientDTO.CodOcupacion = client.i_codigo_ocupacion;
                //clientDTO.CodOcupacion = codigoOcupacion(client);
                clientDTO.NumIdentificacion = client.s_numero_identificacion;
                clientDTO.Fechaexpedicion = client.d_fecha_expedicion;
                //clientDTO.LugarExpedicion = lugarExpedicion(client);
                clientDTO.LugarExpedicion = client.s_lugar_expedicion;

                clientDTO.IdentificacionCliente = client.i_identificacion_cliente;
                clientDTO.NombreCompleto = client.s_nombre_completo;

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
         

        public static String codigoTipoIdent(Client client)
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



        internal static ClientDTO delClientById(Client client)
        {
            return CreateClients2(client);
        }
    }
}
