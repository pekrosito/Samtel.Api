using System.Configuration;
using Samtel.Application;
using Samtel.Domain.Models;
using Samtel.Application.BusinessService;

namespace Samtel.Api.Configuration
{
    public class RestConfigurationManager : IConfigurationManager
    {
        private readonly IParameterRepository _parameterRepository;
        
        public RestConfigurationManager(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public string RelativeUrlProcessMonitor()
        {
            return ConfigurationManager.AppSettings["Office:urlToHangfire"];
        }

        public string UrlOffice()
        {
            return ConfigurationManager.AppSettings["Office:urlBase"];
        }
        
         public int GetMinutesForDurationToken(SystemType system)
        {
            switch (system)
            {
                case SystemType.Desktop: return 60;//int.Parse(_parameterRepository.GetValue("session:Office:minutesDurationToken"));
                default: return 0;
            }
        }
        /*
        public string GetSmsUserName()
        {
            return ConfigurationManager.AppSettings["sms:userName"];
        }

        public string GetSmsPassword()
        {
            return ConfigurationManager.AppSettings["sms:password"];
        }

        public string GetSmsApiKey()
        {
            return ConfigurationManager.AppSettings["sms:apikey"];
        }

        public string GetFromEmail()
        {
            return ConfigurationManager.AppSettings["email:from"];
        }

        public string GetTokenEmailService()
        {
            return ConfigurationManager.AppSettings["email:token"];
        }

        public int MaxDistanceSearchTruck()
        {
            return int.Parse(_parameterRepository.GetValue("order:maxDistanceSearchTruckInMeters"));
        }

        public int SleepForTruckAcceptNewOrder()
        {
            return int.Parse(_parameterRepository.GetValue("order:sleepForTruckAcceptNewOrderInMiliseconds"));
        }

        public int MaxIntentsForSearchTruck()
        {
            return int.Parse(_parameterRepository.GetValue("order:maxIntentsForSearchTruck"));
        }

        public int GetMinutesExecuteJobForOrderNotDelivery()
        {
            return int.Parse(_parameterRepository.GetValue("order:getMinutesExecuteJobForOrderNotDelivery"));
        }

        public int GetMaxMinutesForAlertDeliveryOrder()
        {
            return int.Parse(_parameterRepository.GetValue("order:getMinutesForAlertDeliveryOrder"));
        }

        public int GetMinutesForReassignNotDeliveryOrder()
        {
            return int.Parse(_parameterRepository.GetValue("order:getMinutesForReassignNotDeliveryOrder"));
        }

        public int GetMinutesExecuteJobForOrderNotAssigned()
        {
            return int.Parse(_parameterRepository.GetValue("order:getMinutesExecuteJobForOrderNotAssigned"));
        }

        public int GetMinutesForSearchNotAssignedOrder()
        {
            return int.Parse(_parameterRepository.GetValue("order:getMinutesForSearchNotAssignedOrder"));
        }

        public string GetAzureNotificationConnectionStringConsumer()
        {
            return ConfigurationManager.AppSettings["azure:notification:connectionString:consumer"];
        }

        public string GetAzureNotificationConnectionStringTruck()
        {
            return ConfigurationManager.AppSettings["azure:notification:connectionString:truck"];
        }

        public string GetSmsfromNumber()
        {
            return ConfigurationManager.AppSettings["sms:fromNumber"];
        }

        public int GetMinutesForSearchNotDeliveryConsumerOrder()
        {
            return int.Parse(_parameterRepository.GetValue("order:getMinutesForSearchNotDeliveryConsumerOrder"));
        }

        public int GetMinutesExecuteJobForOrderNotDeliveryByConsumer()
        {
            return int.Parse(_parameterRepository.GetValue("order:getMinutesExecuteJobForOrderNotDeliveryByConsumer"));
        }*/
    }
}