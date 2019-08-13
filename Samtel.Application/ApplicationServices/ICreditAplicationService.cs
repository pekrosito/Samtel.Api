using Samtel.Application.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices
{
    public interface ICreditAplicationService
    {
        List<CreditDTO> listCredits();
        bool metodoPost(CreditDTO credit);
        bool metodoEliminar(int id);
        bool metodoActualizar(CreditDTO credit,int id);
    }
}
