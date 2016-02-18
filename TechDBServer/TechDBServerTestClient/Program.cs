using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDBServer;
using System.ServiceModel;
using Microsoft.ServiceBus;

namespace TechDBServerTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var cf = new ChannelFactory<ITechDBServerChannel>(
                        new NetTcpRelayBinding(),
                        new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb", "sbcwtechdb", "TechDBService")));

            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior 
            { TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "+6swweotZ41Shsgbcoz5faezZS4umVHdHyIC7sYzVzw=") });

            using (var ch = cf.CreateChannel())
            {
                List<string> outputList = ch.GetToolTypes();
                foreach (var item in outputList)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Get ball nose:");
                List<string> outputList2 = ch.GetTools("Ball End Mill");
                foreach (var item in outputList2)
                {
                    Console.WriteLine(item);
                }
               
            }

            Console.ReadLine();
        }
    }
}
