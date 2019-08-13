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
                name= person.name,
                surname = person.surname
            };
        }


        public static List<PersonDTO> listPersons(List<Person> client)
        {
            List<PersonDTO> persons = new List<PersonDTO>();
            foreach (Person item in client)
            {

                persons.Add(CreatePerson(item));
            }
            return persons;
        }


        public static String nombreCompleto(String value)
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
            //nombre completo de TABLA CREDIT
            nomenclatura.Add("A", "Alto");
            nomenclatura.Add("B", "Bajo");
            nomenclatura.Add("N", "Natural");
            nomenclatura.Add("R", "Regional");
            nomenclatura.Add("0", "Inicial");
            nomenclatura.Add("1", "Intermedio");
            return nomenclatura[value];
        }

        public static String nombreCompletoInt(int value)
        {
            Dictionary<int, string> nomenclatura = new Dictionary<int, string>();
           
            //nombre completo de TABLA CREDIT
          
            nomenclatura.Add(0, "Inicial");
            nomenclatura.Add(1, "Intermedio");
            nomenclatura.Add(2, "Final");
            return nomenclatura[value];
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
            try
            {
              
               // String nomenclaturaCompletaTipoIdent = nombreCompleto(client.s_codigo_tipo_ident);
                //String nomenclaturaCompletaCodigoOcu = nombreCompleto(client.i_codigo_ocupacion);
                //String fecha = client.d_fecha_expedicion.ToString("dd/MM/yyyy");
                //String Expedicion = lugarExpedicion(client.s_lugar_expedicion);

                clientDTO.codigoNaturalezaCliente = client.s_codigo_naturaleza_cliente;
                //clientDTO.codigoOcupacion = nomenclaturaCompletaTipoIdent;
                clientDTO.codigoOcupacion = client.i_codigo_ocupacion;
                //clientDTO.codigoTipoIdent = nomenclaturaCompletaCodigoOcu;
                clientDTO.codigoTipoIdent = client.s_codigo_tipo_ident;
                clientDTO.numeroIdentificacion = client.s_numero_identificacion;
                //clientDTO.fechaExpedicion = fecha;
                clientDTO.fechaExpedicion = client.d_fecha_expedicion;
                //clientDTO.lugarExpedicion = Expedicion;
                clientDTO.lugarExpedicion = client.s_lugar_expedicion;
                clientDTO.identificacionCliente = client.i_identificacion_cliente.Value;
                clientDTO.nombreCompleto = client.s_nombre_completo;

            }
            catch (Exception ex)
            {

                throw;
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


        public static CreditDTO CreateCredit(BigCrediPremium credit)
        {
            String nomenclaturaCompletaCalifRiesgo = nombreCompleto(credit.s_peor_calif_riesgo);
            String nomenclaturaCompletaTipoCliente = nombreCompleto(credit.s_tipo_cliente);
            String nomenclaturaCompletaCredCorte = nombreCompletoInt(credit.i_nro_cred_corte);
            return new CreditDTO
            {
                CodigoCliente  = credit.i_codigo_cliente,
                MoraMaximaCliente = credit.i_mora_maxima_cliente,
                PeorCalifRiesgo = nomenclaturaCompletaCalifRiesgo,
                CalifRiesgo  = credit.s_calif_riesgo,
                NroCredCorte = nomenclaturaCompletaCredCorte,
                MoraMaxMes  = credit.i_mora_max_6_mes,
                TipoCliente = nomenclaturaCompletaTipoCliente,
                LineaCredito = credit.i_linea_credito
            };
        }

        // Lista de credits
        public static List<CreditDTO> listCredits(List<BigCrediPremium> credit)
        {
            List<CreditDTO> credits = new List<CreditDTO>();
            foreach (BigCrediPremium item in credit)
            {

                credits.Add(CreateCredit(item));
            }
            return credits;
        }


        public static IdentificationDTO CreateIdentification(Identification identification)
        {

            return new IdentificationDTO
            {
                id = identification.Id,
                identification = identification.identification
            };
        }


        public static List<IdentificationDTO> listIdentifications(List<Identification> identification)
        {
            List<IdentificationDTO> identifications = new List<IdentificationDTO>();
            foreach (Identification item in identification)
            {

                identifications.Add(CreateIdentification(item));
            }
            return identifications;
        }



        public static OcupationDTO CreateOcupation(Ocupation ocupation)
        {

            return new OcupationDTO
            {
                id = ocupation.Id,
                identification = ocupation.ocupation
            };
        }


        public static List<OcupationDTO> listOcupations(List<Ocupation> ocupation)
        {
            List<OcupationDTO> ocupations = new List<OcupationDTO>();
            foreach (Ocupation item in ocupation)
            {

                ocupations.Add(CreateOcupation(item));
            }
            return ocupations;
        }

    }
}
