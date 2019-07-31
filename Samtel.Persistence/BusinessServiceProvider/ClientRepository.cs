using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Application.BusinessService;
using Samtel.Persistence.BusinessServiceProvider.Base;
using Samtel.Domain.Models.Entities;
using Samtel.Application.BusinessService.Base;
using Samtel.Application;

namespace Samtel.Persistence.BusinessServiceProvider
{
   public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
         private readonly RepositoryBase<Person> _RepositoryBase;

         public ClientRepository(IContext context, RequestContext requestContext)
             : base(context, requestContext)
        {
        }

         public IEnumerable<Client> getClients()
        {

            IEnumerable<Client> listClients = new List<Client>();

            listClients = Query<Client>("SELECT s_codigo_naturaleza_cliente, s_codigo_tipo_ident,i_codigo_ocupacion,s_numero_identificacion,d_fecha_expedicion,s_lugar_expedicion,i_identificacion_cliente,s_nombre_completo FROM BIG_CLIENTES_TEMP").ToList();
                  
            return listClients;
        }
    }
}
