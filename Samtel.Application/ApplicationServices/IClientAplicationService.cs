using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Domain.Models.Entities;

namespace Samtel.Application.ApplicationServices
{
    public interface IClientAplicationService
    {
      
        IEnumerable<ClientDTO> getClients();
        Boolean deleteClientById(int id);

        Boolean createClient(ClientDTO clientRequest);
        Boolean editClient(int id, ClientDTO clientRequest);
    }
}
