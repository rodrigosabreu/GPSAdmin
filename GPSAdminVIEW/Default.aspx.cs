using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GPSAdminBLL.UsuarioBLL obj = new GPSAdminBLL.UsuarioBLL();
                DataTable dt = obj.Logar(TextBox1.Text, TextBox2.Text);

                if (dt.Rows.Count > 0)
                {
                    Session["Pioneira"] = "1";
                    Session["Usuario"] = dt.Rows[0]["usuario"].ToString();
                    Session["Nome"] = dt.Rows[0]["Nome"].ToString();
                    Session["GrupoID"] = dt.Rows[0]["id_grupo"].ToString();
                    Session["Grupo"] = dt.Rows[0]["nome_grupo"].ToString();
                    Session["ClienteID"] = dt.Rows[0]["id_cliente"].ToString();

                    Response.Redirect("Home.aspx");

                }
                else
                {
                    lbl_msg.Text = "Usuário ou senha inválidos!";
                }

            }
            catch (Exception ex)
            {
                lbl_msg.Text = ex.Message;
            }
        }
    }
}