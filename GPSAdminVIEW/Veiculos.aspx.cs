using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class Veiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int clienteID;
            int veiculoID;
            DataTable dt;

            if (Request.QueryString["Vid"] != null)
            {

            }
            else
            {
                clienteID = 0;

                if (Request.QueryString["Cid"] == null)
                {

                    if (Session["Grupo"].ToString() == "Administrador")
                    {
                        Response.Redirect("VeiculosEscolheCliente.aspx");
                    }
                }

            }

        }
    }
}