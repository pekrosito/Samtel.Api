using Samtel.Application.BusinessService.Base;
using Samtel.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.BusinessService
{
    public interface ICreditRepository : IRepository<BigCrediPremium>
    {
        List<BigCrediPremium> listCredits();

        bool metodoPost(BigCrediPremium credit);
        bool metodoEliminar(int id);

        bool metodoActualizar(BigCrediPremium credit, int id);
    }
}
