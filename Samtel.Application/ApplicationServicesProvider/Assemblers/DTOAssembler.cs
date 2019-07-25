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
    }
}
