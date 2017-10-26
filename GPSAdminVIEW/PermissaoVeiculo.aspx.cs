using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class PermissaoVeiculo : System.Web.UI.Page
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
                        Response.Redirect("PermissaoVeiculoEscolheCliente.aspx");
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
            ddl_usuarios.DataSource = objUsu.ListarUsuariosCtrlVeiculo(clienteID);
            ddl_usuarios.DataBind();
            ddl_usuarios.Items.Insert(0, new ListItem("Selecione o Usuário", "-1"));                      

            GPSAdminBLL.VeiculoBLL objVeiculo = new GPSAdminBLL.VeiculoBLL();

            cbl_veiculos.DataValueField = "cod_veiculo";
            cbl_veiculos.DataTextField = "veiculo";
            cbl_veiculos.DataSource = objVeiculo.SelecionaVeiculosCliente(clienteID);
            cbl_veiculos.DataBind();

            //CheckBoxList1.Items.FindByValue("3").Selected = true;                 

        }

        protected void ddl_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpa_checkbox();
            //SelecionaPerfilFilial(Convert.ToInt32(this.ddl_usuarios.SelectedValue));
            SelecionaPerfilVeiculo(Convert.ToInt32(this.ddl_usuarios.SelectedValue));

        }

        private void limpa_checkbox()
        {
            for (int i = 0; i < cbl_veiculos.Items.Count; i++)
            {
                cbl_veiculos.Items[i].Selected = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                InserePermissaoVeiculo();
            }
            catch (Exception Ex)
            {
                lbl_msg.Text = Ex.Message;
            }
        }


        protected void InserePermissaoVeiculo()
        {
            
            GPSAdminBLL.VeiculoBLL obj = new GPSAdminBLL.VeiculoBLL();

            int usuarioID = Convert.ToInt32(ddl_usuarios.SelectedValue);
            int cod_veiculo;

            if (usuarioID == -1)
                throw new System.ArgumentException("Favor, selecione o usuário");

            obj.RemovePerfilVeiculo(usuarioID);


            for (int i = 0; i < cbl_veiculos.Items.Count; i++)
            {
                if (cbl_veiculos.Items[i].Selected)
                {

                    cod_veiculo = Convert.ToInt32(cbl_veiculos.Items[i].Value);
                    obj.InserePerfilVeiculo(usuarioID, cod_veiculo);

                }
            }

            lbl_msg.Text = "Perfil cadastrado com sucesso!";

        
        }



        private void SelecionaPerfilVeiculo(int id_usuario)
        {
            GPSAdminBLL.VeiculoBLL obj = new GPSAdminBLL.VeiculoBLL();
            DataTable dt = obj.SelecionaPerfilVeiculo(id_usuario);

            int id_veiculo;
            int id_veiculo_banco;



            foreach (DataRow linha in dt.Rows)
            {
                id_veiculo = Convert.ToInt32(linha["cod_veiculo"].ToString());


                for (int i = 0; i < cbl_veiculos.Items.Count; i++)
                {
                    id_veiculo_banco = Convert.ToInt32(cbl_veiculos.Items[i].Value);



                    if (id_veiculo == id_veiculo_banco)
                    {
                        cbl_veiculos.Items[i].Selected = true;
                    }
                }

            }


            if (dt.Rows.Count == 0)
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


    }
}