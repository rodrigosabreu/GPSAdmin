using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class FiliaisBuscaLista : System.Web.UI.Page
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

                PreencheGridFiliais(Convert.ToInt32(Session["ClienteID"].ToString()));
                div_cliente.Visible = false;             
            }
            
            
        }


        protected void PreencheGridFiliais(int clienteID)
        {
            GPSAdminModel.FilialModel objCli = new GPSAdminModel.FilialModel();
            objCli.ClienteID = clienteID;           
            
            GPSAdminBLL.FilialBLL obj = new GPSAdminBLL.FilialBLL();
            GridView1.DataSource = obj.ListarFiliaisClienteID(objCli);
            GridView1.DataBind();
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ddl_cliente = (DropDownList)UCEscolheCliente1.FindControl("ddl_cliente");

                if (ddl_cliente.SelectedValue == "-1")
                    throw new Exception("Selecione o Cliente");


                GPSAdminModel.FilialModel objCli = new GPSAdminModel.FilialModel();
                objCli.ClienteID = Convert.ToInt32(ddl_cliente.SelectedValue);

                GPSAdminBLL.FilialBLL obj = new GPSAdminBLL.FilialBLL();
                GridView1.DataSource = obj.ListarFiliaisClienteID(objCli);
                GridView1.DataBind();
                lbl_msg.Text = "";
            }
            catch (Exception ex)
            {
                lbl_msg.Text = ex.Message;
                GridView1.DataBind();
            }



        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text == "1")
                {
                    e.Row.Cells[2].Text = "Ativo";
                }
                else
                {
                    e.Row.Cells[2].Text = "Invativo";
                }


                ddl_cliente = (DropDownList)UCEscolheCliente1.FindControl("ddl_cliente");


                e.Row.Cells[1].Text = "<a href='Filiais.aspx?Fid=" + e.Row.Cells[0].Text + "'>" + e.Row.Cells[1].Text + "</a>";

            }
        }



    }
}