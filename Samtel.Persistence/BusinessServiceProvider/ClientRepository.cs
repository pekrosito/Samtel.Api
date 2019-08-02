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
using Dapper;
using System.Data.SqlClient;

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
         public Boolean delClientById(int id)
         {
             Boolean result = false;

             try
             {
                  Query<Client>("DELETE FROM BIG_CLIENTES_TEMP WHERE i_identificacion_cliente =" + id).FirstOrDefault();
                  result = true;
         
             }
             catch (Exception)
             {
                 result = false;                 
             }
             return result;
         }

         public Boolean save(Client clientRequest)
         {
               Boolean result = false;
             try
             {
                 Query<Client>("INSERT INTO BIG_CLIENTES_TEMP (s_codigo_naturaleza_cliente,s_codigo_tipo_ident,i_codigo_ocupacion,s_numero_identificacion,d_fecha_expedicion,s_lugar_expedicion,i_identificacion_cliente,s_nombre_completo)  VALUES ( '"+clientRequest.s_codigo_naturaleza_cliente + "', '" + clientRequest.s_codigo_tipo_ident+ "', '" + clientRequest.i_codigo_ocupacion + "', '" + clientRequest.s_numero_identificacion + "', '" + clientRequest.d_fecha_expedicion + "', '" + clientRequest.s_lugar_expedicion + "', " + clientRequest.i_identificacion_cliente +",'"+ clientRequest.s_nombre_completo + "')" );
                                
                result = true;
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
                 result = false;  
             }
            return result;
         }
       public Boolean update(Client clientRequest)
         {
             Boolean result = false;
             try
             {
                 Query<Client>("UPDATE BIG_CLIENTES_TEMP SET s_codigo_naturaleza_cliente = '" + clientRequest.s_codigo_naturaleza_cliente + "', s_codigo_tipo_ident = '"+ clientRequest.s_codigo_tipo_ident + "', i_codigo_ocupacion = '"+ clientRequest.i_codigo_ocupacion +"', s_numero_identificacion = '" + clientRequest.s_numero_identificacion+ "', d_fecha_expedicion = '"+ clientRequest.d_fecha_expedicion+"', s_lugar_expedicion = '"+ clientRequest.s_lugar_expedicion +"', s_nombre_completo ='"+ clientRequest.s_nombre_completo+"' where i_identificacion_cliente = " + clientRequest.i_identificacion_cliente);

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
