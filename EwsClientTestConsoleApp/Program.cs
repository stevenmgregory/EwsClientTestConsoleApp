using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ews.Client;
using Ews.Common;

namespace EwsClientTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EwsServerConnectionDetails EsSrv = new EwsServerConnectionDetails()
            {
                UserName = "*****",
                Password = "*****",
                EwsEndpoint = "http://192.168.68.200:80/EcoStruxure/DataExchange"
            };
            

            using (var ewsClient = CreateConnection(EsSrv))
            {
                var keepGoing = true;
                do
                {
                    // GET ACTIVE ALARMS
                    GetAlarmEventsResponse activeAlarms = ewsClient.GetAlarmEvents(1, 3, "", null);

                    Console.ReadKey();

                } while (keepGoing);
                
            } 
        }
        public class EwsServerConnectionDetails
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string EwsEndpoint { get; set; }
        }
        
        static EwsClient CreateConnection(EwsServerConnectionDetails EsSrv)
        {
            var ewsSecurity = new EwsSecurity
            {
                UserName = EsSrv.UserName,
                Password = EsSrv.Password
            };
            return new EwsClient(ewsSecurity, EsSrv.EwsEndpoint, EwsVersion.Ews12);
        }
    }
}
