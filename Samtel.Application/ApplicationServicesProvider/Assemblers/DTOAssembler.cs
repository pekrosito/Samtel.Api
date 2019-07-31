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


        public static String nombreCompleto(String client)
        {
            Dictionary<string, string> nomenclatura = new Dictionary<string, string>();
            nomenclatura.Add("CC","Cedula de Ciudadania");
            nomenclatura.Add("CE", "Cedula de Extranjeria");
            nomenclatura.Add("NIT","Numero de Identificación Tributaria");
            nomenclatura.Add("RCN","Residenciado");
            nomenclatura.Add("TI","Tarjeta de Identidad");
            nomenclatura.Add("HOGA", "Hogar");
            nomenclatura.Add("INDE", "Independiente");
            nomenclatura.Add("FARM", "");
            nomenclatura.Add("ESTU", "");
            nomenclatura.Add("OTRA", "Otra Ocuapción");
            nomenclatura.Add("NAPL", "");   
            nomenclatura.Add("ASAL", "Asalariado");
            nomenclatura.Add("RENT", "Retirado");
            nomenclatura.Add("RELI", "");
            nomenclatura.Add("PENS", "Pensionado");
            nomenclatura.Add("","");
            return nomenclatura[client];
        }

        public static String lugarExpedicion(String client)
        {
            String resultado;
            if (client.Equals("//"))
            {
                resultado = "Sin Lugar de Expedición";
            }
            else
            {
                resultado = client;
            }
            return resultado;
        }

        public static ClientDTO createCliente(Client client)
        {

            ClientDTO clientDTO = new ClientDTO();
            String nomenclaturaCompletaTipoIdent = nombreCompleto(client.s_codigo_tipo_ident);
            String nomenclaturaCompletaCodigoOcu = nombreCompleto(client.i_codigo_ocupacion);
            String fecha = client.d_fecha_expedicion.ToString("dd/MM/yyyy");
            String Expedicion = lugarExpedicion(client.s_lugar_expedicion);

            clientDTO.codigoNaturalezaCliente = client.s_codigo_naturaleza_cliente;
            clientDTO.codigoOcupacion = nomenclaturaCompletaTipoIdent;
            clientDTO.codigoTipoIdent = nomenclaturaCompletaCodigoOcu;
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
