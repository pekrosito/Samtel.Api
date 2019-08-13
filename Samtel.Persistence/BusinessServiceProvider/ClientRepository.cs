using Samtel.Application;
using Samtel.Application.BusinessService;
using Samtel.Application.BusinessService.Base;
using Samtel.Domain.Models.Entities;
using Samtel.Persistence.BusinessServiceProvider.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly RepositoryBase<Client> _RepositoryBase;

        public ClientRepository(IContext context, RequestContext requestContext): base(context, requestContext)
        {
        }

        public List<Client> getClients()
        {
            return Query<Client>("SELECT TOP 100 s_codigo_naturaleza_cliente, s_codigo_tipo_ident,i_codigo_ocupacion,s_numero_identificacion,d_fecha_expedicion,s_lugar_expedicion,i_identificacion_cliente,s_nombre_completo FROM BIG_CLIENTES_TEMP").AsList();
        }
    }
}
