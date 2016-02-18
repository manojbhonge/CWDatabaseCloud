using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TechDBServer
{
    [DataContract]
    public class ToolData
    {      
        private string toolName;
        
        [DataMember]
        public string ToolName
        {
            get { return toolName; }
            set { toolName = value; }
        }
    }
}