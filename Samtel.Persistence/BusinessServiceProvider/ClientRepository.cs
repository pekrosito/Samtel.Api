using Samtel.Application;
using Samtel.Application.BusinessService;
using Samtel.Application.BusinessService.Base;
using Samtel.Domain.Models.Entities;
using Samtel.Persistence.BusinessServiceProvider.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly RepositoryBase<Client> _RepositoryBase;

        public ClientRepository(IContext context, RequestContext requestContext): base(context, requestContext)
        {
        }

        public bool createClient(Client client)
        {
            Boolean result = false;
            try
            {
                Query<Client>("INSERT INTO BIG_CLIENTES_TEMP (s_codigo_naturaleza_cliente,s_codigo_tipo_ident,i_codigo_ocupacion,s_numero_identificacion,s_lugar_expedicion,i_identificacion_cliente,s_nombre_completo)  VALUES ( '" + client.s_codigo_naturaleza_cliente + "', '" + client.s_codigo_tipo_ident + "', '" + client.i_codigo_ocupacion + "', '" + client.s_numero_identificacion +  "', '" + client.s_lugar_expedicion + "', " + client.i_identificacion_cliente + ",'" + client.s_nombre_completo + "')");

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }
            return result;
        }

        public List<Client> listClients()
        {
            var testing = Query<Client>("SELECT * FROM BIG_CLIENTES_TEMP  ").ToList();
            return testing;
        }

        public bool updateClient(Client client)
        {
            Boolean result = false;
            try
            {
                Query<Client>("UPDATE BIG_CLIENTES_TEMP SET s_codigo_naturaleza_cliente = '" + client.s_codigo_naturaleza_cliente + "',s_codigo_tipo_ident = '" + client.s_codigo_tipo_ident + "', i_codigo_ocupacion = '" + client.i_codigo_ocupacion + "', s_numero_identificacion = '" + client.s_numero_identificacion + "', s_lugar_expedicion = '" + client.s_lugar_expedicion + "', s_nombre_completo = '" + client.s_nombre_completo + "' WHERE i_identificacion_cliente = " + client.i_identificacion_cliente );

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }
            return result;
        }
    }
}
