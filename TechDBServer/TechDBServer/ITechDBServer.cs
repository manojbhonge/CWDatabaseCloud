using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TechDBServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITechDBServer
    {
        [OperationContract]
        List<ToolData> GetToolTypes();

        [OperationContract]
        List<ToolData> GetTools(string ToolType);
    }

    public interface ITechDBServerChannel : ITechDBServer, IClientChannel { }

}
