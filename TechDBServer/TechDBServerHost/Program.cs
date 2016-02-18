using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDBServer;
using System.ServiceModel;
using Microsoft.ServiceBus;

namespace TechDBServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(TechDBServer.TechDBServer));

            //sh.AddServiceEndpoint(
            //   typeof(IProblemSolver), new NetTcpBinding(),
            //   "net.tcp://localhost:9358/solver");

            sh.AddServiceEndpoint(
               typeof(ITechDBServer), new NetTcpRelayBinding(),
               ServiceBusEnvironment.CreateServiceUri("sb", "sbcwtechdb", "TechDBService"))
                .Behaviors.Add(new TransportClientEndpointBehavior
                {
                    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "+6swweotZ41Shsgbcoz5faezZS4umVHdHyIC7sYzVzw=")
                });

            sh.Open();

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            sh.Close();
        }
    }
}
