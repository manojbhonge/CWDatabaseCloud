using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechDBServer;
using System.ServiceModel;
using Microsoft.ServiceBus;

namespace cwtechdbWebRole
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                if(!authenticationManager.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
        }

        protected void gm_gettooltypes_Click(object sender, EventArgs e)
        {
            var cf = new ChannelFactory<ITechDBServerChannel>(
                        new NetTcpRelayBinding(),
                        new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb", "sbcwtechdb", "TechDBService")));

            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior { TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "+6swweotZ41Shsgbcoz5faezZS4umVHdHyIC7sYzVzw=") });

            using (var ch = cf.CreateChannel())
            {
                List<ToolData> outputList = ch.GetToolTypes();
                DropDownList1.Items.Clear();
                foreach (var item in outputList)
                {
                    DropDownList1.Items.Add(item.ToolName);
                    //Response.Write(item.ToolName);
                }

                

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cf = new ChannelFactory<ITechDBServerChannel>(
                        new NetTcpRelayBinding(),
                        new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb", "sbcwtechdb", "TechDBService")));

            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior { TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "+6swweotZ41Shsgbcoz5faezZS4umVHdHyIC7sYzVzw=") });

            using (var ch = cf.CreateChannel())
            {
                List<ToolData> outputList = ch.GetTools(DropDownList1.Text);
                CheckBoxList1.Items.Clear();
                foreach (var item in outputList)
                {
                    CheckBoxList1.Items.Add(item.ToolName);
                    //Response.Write(item.ToolName);
                }



            }
        }
    }
}