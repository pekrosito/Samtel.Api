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
    public class CreditRepository : RepositoryBase<BigCrediPremium>, ICreditRepository
    {

        private readonly RepositoryBase<Client> _RepositoryBase;

        public CreditRepository(IContext context, RequestContext requestContext): base(context, requestContext)
        {
        }

        public List<BigCrediPremium> listCredits()
        {
            var testing = Query<BigCrediPremium>("SELECT * FROM BIG_CREDIPREMIUM").ToList();
            // _cacheService.Add(keyCache, paymentMethods);
            return testing;
        }


        public bool metodoPost(BigCrediPremium credit)
        {
            bool valicion = false;
            try{
                Query<BigCrediPremium>("INSERT INTO BIG_CREDIPREMIUM (i_codigo_cliente, i_mora_maxima_cliente, s_peor_calif_riesgo, s_calif_riesgo, i_nro_cred_corte, i_mora_max_6_mes,s_tipo_cliente,i_linea_credito) VALUES ('" + credit.i_codigo_cliente + "','" + credit.i_mora_maxima_cliente + "','" + credit.s_peor_calif_riesgo + "','" + credit.s_calif_riesgo + "','" + credit.i_nro_cred_corte + "','" + credit.i_mora_max_6_mes + "','" + credit.s_tipo_cliente + "','" + credit.i_linea_credito + "')");
                valicion = true;
            } 
            catch{
                valicion = false;
            }
            
            return valicion;   
        }

        public bool metodoEliminar(int id)
        {
            bool validacion = false;

            try
            {
                Query<BigCrediPremium>("DELETE FROM  BIG_CREDIPREMIUM WHERE i_codigo_cliente =" + id);
                validacion = true;
            }
            catch
            {
                validacion = false;
            }

            return validacion;   
        }

        public bool metodoActualizar(BigCrediPremium credit, int id)
        {
            bool validacion = false;
            try
            {
                string a = "UPDATE BIG_CREDIPREMIUM SET i_mora_maxima_cliente = " + credit.i_mora_maxima_cliente + ", s_peor_calif_riesgo = " + "'" + credit.s_peor_calif_riesgo + "'" + ", s_calif_riesgo = " + "'" + credit.s_calif_riesgo + "'" + ", i_nro_cred_corte = " + credit.i_nro_cred_corte + ", i_mora_max_6_mes = " + credit.i_mora_max_6_mes + ", s_tipo_cliente = " + "'" + credit.s_tipo_cliente + "'" + ", i_linea_credito = " + "'" + credit.i_linea_credito + "'" + " WHERE i_codigo_cliente = " + id;
                Query<BigCrediPremium>(a);
                validacion = true;
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX);
                validacion = false;
            }

            return validacion;   

        }
    }
}
