using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class ClientesBuscaLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GPSAdminBLL.ClienteBLL obj = new GPSAdminBLL.ClienteBLL();

            GridView1.DataSource = obj.BuscaCliente(TextBox1.Text);
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            string busca = TextBox1.Text;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text == "1")
                {
                    e.Row.Cells[5].Text = "Ativo";
                }
                else
                {
                    e.Row.Cells[5].Text = "Invativo";
                }

                e.Row.Cells[1].Text = "<a href='Clientes.aspx?id=" + e.Row.Cells[0].Text + "&busca=" + busca + "'>" + e.Row.Cells[1].Text + "</a>";
            }
        }
    }
}