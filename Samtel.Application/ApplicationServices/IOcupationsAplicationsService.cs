using System;
using System.Collections.Generic;
using Samtel.Application.ApplicationServices.DTOs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Samtel.Application.ApplicationServices
{
    public interface IOcupationsAplicationsService
    {
        IEnumerable<OcupationsDTO> getOcupations();
    }
}   
