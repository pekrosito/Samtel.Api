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
                nombre = person.name,
                apellido = person.surname
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
            List<CreditDTO> _listClient = new List<CreditDTO>();

            foreach (BigCrediPremium item in listCredits)
            {
                _listClient.Add(CreateCredit(item));
            }
            return _listClient;
        }
    }
}
