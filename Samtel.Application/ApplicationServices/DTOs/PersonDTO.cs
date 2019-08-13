using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices.DTOs
{
    public class PersonDTO : ClientDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
