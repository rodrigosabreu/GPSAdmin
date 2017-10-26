using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class UsuariosBuscaLista : System.Web.UI.Page
    {

        DropDownList ddl_cliente;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Grupo"].ToString() == "Administrador")
            {
                //UserControl uc = (UserControl)Page.LoadControl("UCEscolheCliente.ascx");
                //div1.Controls.Add(uc);
                div_cliente.Visible = true;
            }
            else
            {

                PreencheGridUsuarios(Convert.ToInt32(Session["ClienteID"].ToString()));
                div_cliente.Visible = false;
            }
        }


        private void PreencheGridUsuarios(int clienteID)
        {
            GPSAdminBLL.UsuarioBLL obj = new GPSAdminBLL.UsuarioBLL();
            GridView1.DataSource = obj.ListarUsuarios(clienteID);
            GridView1.DataBind();

        }


        protected void Button1_Click(object sender, EventArgs e)
        {


            try
            {
                ddl_cliente = (DropDownList)UCEscolheCliente1.FindControl("ddl_cliente");

                if (ddl_cliente.SelectedValue == "-1")
                    throw new Exception("Selecione o Cliente");

                PreencheGridUsuarios(Convert.ToInt32(ddl_cliente.SelectedValue));

                lbl_msg.Text = "";
            }
            catch (Exception ex)
            {
                lbl_msg.Text = ex.Message;                
            }
            
            
            
            
            
            
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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


                e.Row.Cells[1].Text = "<a href='Usuarios.aspx?Uid=" + e.Row.Cells[0].Text + "'>" + e.Row.Cells[1].Text + "</a>";

            }
        }
    }
}