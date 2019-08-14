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
        public static CreditDTO CreateCredit(BigCrediPremium credit)
        {

            return new CreditDTO
            {
                calificacionRiesgo = credit.s_calif_riesgo,
                codigoCliente = credit.i_codigo_cliente,
                lineaCredito = credit.i_linea_credito,
                moraMaxima6Meses = credit.i_mora_max_6_mes,
                moraMaximaCliente = credit.i_mora_maxima_cliente,
                numeroCreditoCorte = credit.i_nro_cred_corte,
                peorCalificacionRiesgo = credit.s_peor_calif_riesgo,
                tipoCliente = credit.s_tipo_cliente
            };
        }
        public static List<CreditDTO> listarCredits(List<BigCrediPremium> listCredits)
        {
            List<CreditDTO> _listCredit = new List<CreditDTO>();

            foreach (BigCrediPremium item in listCredits)
            {
                _listCredit.Add(CreateCredit(item));
            }
            return _listCredit;
        }

        public static ClientDTO CreateClient(Client client)
        {
            return new ClientDTO
            {
               codigo_naturaleza_cliente = client.s_codigo_naturaleza_cliente,
               codigo_ocupacion =client.i_codigo_ocupacion,
               codigo_tipo_ident = client.s_codigo_tipo_ident,
               fecha_expedicionn = client.d_fecha_expedicion,
               identificacion_cliente = client.i_identificacion_cliente,
               lugar_expedicion = client.s_lugar_expedicion,
               nombre_completo = client.s_nombre_completo,
               numero_identificacion = client.s_numero_identificacion
            };
        }
        public static List<ClientDTO> listarClients(List<Client> listClients)
        {
            List<ClientDTO> _listClient = new List<ClientDTO>();

            foreach (Client item in listClients)
            {
                _listClient.Add(CreateClient(item));
            }
            return _listClient;
        }

        public static OcupationDTO CreateOcupation(Ocupations ocupation)
        {
            return new OcupationDTO
            {
                id = ocupation.id,
                ocupation = ocupation.ocupation

            };
        }
        public static List<OcupationDTO> listarOcupations(List<Ocupations> listOcupations)
        {
            List<OcupationDTO> _listOcupation = new List<OcupationDTO>();

            foreach (Ocupations item in listOcupations)
            {
                _listOcupation.Add(CreateOcupation(item));
            }
            return _listOcupation;
        }
        public static IdentificationDTO CreateIdentification(Identification identif)
        {
            return new IdentificationDTO
            {
                id = identif.id,
                identificacion =identif.identification
            };
        }
        public static List<IdentificationDTO> listarIdentifications(List<Identification> listIdentifications)
        {
            List<IdentificationDTO> _listIdentifications = new List<IdentificationDTO>();

            foreach (Identification item in listIdentifications)
            {
                _listIdentifications.Add(CreateIdentification(item));
            }
            return _listIdentifications;
        }
        public static GeneralDTO CreateIdentification2(Identification identif)
        {
            return new GeneralDTO
            {
                id = identif.id,
                description = identif.identification
            };
        }
        public static List<GeneralDTO> listarIdentifications2(List<Identification> listIdentifications)
        {
            List<GeneralDTO> _listIdentifications = new List<GeneralDTO>();

            foreach (Identification item in listIdentifications)
            {
                _listIdentifications.Add(CreateIdentification2(item));
            }
            return _listIdentifications;
        }
        public static GeneralDTO CreateOcupation2(Ocupations ocupation)
        {
            return new GeneralDTO
            {
                id = ocupation.id,
                description = ocupation.ocupation

            };
        }
        public static List<GeneralDTO> listarOcupations2(List<Ocupations> listOcupations)
        {
            List<GeneralDTO> _listOcupation = new List<GeneralDTO>();

            foreach (Ocupations item in listOcupations)
            {
                _listOcupation.Add(CreateOcupation2(item));
            }
            return _listOcupation;
        }
    }
}
