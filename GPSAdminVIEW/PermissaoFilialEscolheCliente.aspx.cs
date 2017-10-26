using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class PermissaoFilialEscolheCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList ddl_cliente = (DropDownList)UCEscolheCliente.FindControl("ddl_cliente");

            if (ddl_cliente.SelectedValue.ToString() == "-1")
            {
                lbl_msg.Text = "Selecione o Cliente";
            }
            else
            {

                Response.Redirect("PermissaoFilial.aspx?Cid=" + ddl_cliente.SelectedValue.ToString());
            }
        }
    }
}