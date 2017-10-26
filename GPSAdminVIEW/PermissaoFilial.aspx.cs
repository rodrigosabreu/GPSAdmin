using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class PermissaoFilial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                int clienteID;

                clienteID = 0;


                if (Request.QueryString["Cid"] == null)
                {

                    if (Session["Grupo"].ToString() == "Administrador")
                    {
                        Response.Redirect("PermissaoFilialEscolheCliente.aspx");
                    }
                }
                else
                {
                    clienteID = Convert.ToInt32(Request.QueryString["Cid"].ToString());
                }


                if (Session["Grupo"].ToString() != "Administrador")
                {
                    clienteID = Convert.ToInt32(Session["ClienteID"].ToString());
                }


                PreencheUsuarios(clienteID);
          

            }


        }


        private void PreencheUsuarios(int clienteID)
        {
                      
            ddl_usuarios.DataValueField = "id";
            ddl_usuarios.DataTextField = "Nome";
            
            GPSAdminBLL.UsuarioBLL objUsu = new GPSAdminBLL.UsuarioBLL();
            ddl_usuarios.DataSource = objUsu.ListarUsuarios(clienteID);
            ddl_usuarios.DataBind();
            ddl_usuarios.Items.Insert(0, new ListItem("Selecione o Usuário", "-1"));  

            GPSAdminModel.FilialModel objFilialModel = new GPSAdminModel.FilialModel();
            objFilialModel.ClienteID = clienteID;

            GPSAdminBLL.FilialBLL objFilialBLL = new GPSAdminBLL.FilialBLL();


            cbl_filiais.DataValueField = "id";
            cbl_filiais.DataTextField = "Nome";
            cbl_filiais.DataSource = objFilialBLL.ListarFiliaisClienteID(objFilialModel);
            cbl_filiais.DataBind();
            
            //CheckBoxList1.Items.FindByValue("3").Selected = true;                 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                InserePermissaoFilial();
            }catch(Exception ex)
            {

                lbl_msg.Text = ex.Message;
            }

            




        }

        private void InserePermissaoFilial()
        {

            

            GPSAdminBLL.FilialBLL obj = new GPSAdminBLL.FilialBLL();
            
            int usuarioID = Convert.ToInt32(ddl_usuarios.SelectedValue);
            int filialID;

            if(usuarioID == -1)
                throw new System.ArgumentException("Favor, selecione o usuário");

            obj.RemovePerfilFilial(usuarioID);
            
            for (int i = 0; i < cbl_filiais.Items.Count; i++)
            {
                if (cbl_filiais.Items[i].Selected)
                {

                    filialID = Convert.ToInt32(cbl_filiais.Items[i].Value);
                    obj.InserePerfilFilial(usuarioID, filialID);

                }
            }

            lbl_msg.Text = "Perfil cadastrado com sucesso!";

        }


        private void limpa_checkbox() {
            for (int i = 0; i < cbl_filiais.Items.Count; i++)
            {
                cbl_filiais.Items[i].Selected = false;                                
            }         
        }


        protected void ddl_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpa_checkbox();
            SelecionaPerfilFilial(Convert.ToInt32(this.ddl_usuarios.SelectedValue));

        }


        private void SelecionaPerfilFilial(int id_usuario)
        {
            GPSAdminBLL.FilialBLL obj = new GPSAdminBLL.FilialBLL();
            DataTable dt = obj.SelecionaPerfilFilial(id_usuario);

            int id_filial;
            int id_filial_banco;

            

            foreach (DataRow linha in dt.Rows)
            {
                 id_filial = Convert.ToInt32(linha["id_filial"].ToString());


                 for (int i = 0; i < cbl_filiais.Items.Count; i++)
                 {
                     id_filial_banco = Convert.ToInt32(cbl_filiais.Items[i].Value);



                     if (id_filial == id_filial_banco)
                     {
                         cbl_filiais.Items[i].Selected = true;
                     }
                 } 

            }


            if(dt.Rows.Count == 0)
            {
                if (id_usuario != -1)
                {
                    lbl_msg.Text = "Usuário sem perfil atribuído";
                }
            }
            else
            {
                lbl_msg.Text = "";
            }

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }



    }
}