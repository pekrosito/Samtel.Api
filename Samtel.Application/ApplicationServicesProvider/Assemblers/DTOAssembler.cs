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
                Nombre = person.name,
                Apellido = person.surname
            };
        }

        public static List<PersonDTO> CreatePersons(List<Person> persons)
        {
            List<PersonDTO> personsDTO = new List<PersonDTO>();

            foreach (Person person in persons)
            {
                
                personsDTO.Add(CreatePerson(person));
            }

            return personsDTO;
        }

        public static ClientDTO CreateClient(Client client)
        {
            ClientDTO clientDTO = new ClientDTO();

            clientDTO.CodNaturaleza = client.s_codigo_naturaleza_cliente;
            clientDTO.CodOcupacion = client.i_codigo_ocupacion;
            clientDTO.CodTipoIdentificacion = client.s_codigo_tipo_ident;
            clientDTO.FechaExpedicion = client.d_fecha_expedicion;
            clientDTO.LugarExpedicion = client.s_lugar_expedicion;
            clientDTO.NombreCompleto = client.s_nombre_completo;
            clientDTO.NumIdentificacion = client.s_numero_identificacion;
            clientDTO.Person = new PersonDTO();

            if (client.i_identificacion_cliente > 0)
            {
                clientDTO.IdentificacionCliente = client.i_identificacion_cliente;
            }

            return clientDTO;
        }

        public static List<ClientDTO> CreateClients(List<Client> clients)
        {
            List<ClientDTO> clientsDTO = new List<ClientDTO>();

            foreach (Client client in clients)
            {
                clientsDTO.Add(CreateClient(client));
            }

            return clientsDTO;
        }
    }
}
