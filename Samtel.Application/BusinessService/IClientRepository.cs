using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models.Entities;
using Samtel.Application.BusinessService.Base;
using Samtel.Application.ApplicationServices.DTOs;

namespace Samtel.Application.BusinessService
{
    public interface IClientRepository : IRepository<Client>
    {
       /* List<Client> getClients();*/
       IEnumerable<Client> getClients();

       Boolean delClientById(int id);

       Boolean save(Client clientRequest);

      Boolean update(Client client);
    }
}
