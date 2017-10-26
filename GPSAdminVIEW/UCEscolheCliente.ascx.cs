using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class UCEscolheCliente : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ddl_cliente.AppendDataBoundItems = true;
                ddl_cliente.Items.Insert(0, new ListItem("Selecione o Cliente", "-1"));

                GPSAdminBLL.ClienteBLL obj = new GPSAdminBLL.ClienteBLL();

                ddl_cliente.DataValueField = "id";
                ddl_cliente.DataTextField = "razaosocial";

                ddl_cliente.DataSource = obj.PreencheDropCliente();
                ddl_cliente.DataBind();
            }

        }
    }
}