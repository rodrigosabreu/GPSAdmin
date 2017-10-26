using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GPSAdminVIEW
{
	public partial class Usuarios : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                try
                {
                    int clienteID;
                    int usuarioID;
                    DataTable dt;

                   



                    if (Request.QueryString["Uid"] != null)
                    {
                        usuarioID = Convert.ToInt32(Request.QueryString["Uid"].ToString());
                        lbl_titulo.Text = "Alteração de Usuários";

                        bt_salvar.Visible = false;
                        bt_atualizar.Visible = true;



                        GPSAdminBLL.UsuarioBLL objUsu = new GPSAdminBLL.UsuarioBLL();
                        dt = objUsu.ConsultaUsuarioCliente(usuarioID);

                        clienteID = Convert.ToInt32(dt.Rows[0]["id_cliente"].ToString());





                        GPSAdminBLL.ClienteBLL objCli = new GPSAdminBLL.ClienteBLL();
                        dt = objCli.BuscaClienteID(clienteID);
                        
                        lbl_cliente.Text = dt.Rows[0]["razaosocial"].ToString();
                        hf_clienteID.Value = clienteID.ToString();

                        dt = objUsu.PesquisaUsuarioID(usuarioID);


                        PreencheDdlFilial(clienteID);



                        hf_id.Value = dt.Rows[0]["id"].ToString();
                        ddl_filial.SelectedValue = dt.Rows[0]["idfilial"].ToString();
                        txt_nome_completo.Text = dt.Rows[0]["Nome"].ToString();
                        txt_login.Text = dt.Rows[0]["usuario"].ToString();
                        txt_email.Text = dt.Rows[0]["email"].ToString();
                        txt_senha.Text = dt.Rows[0]["senha"].ToString();
                        ddl_ctrl_veiculo.SelectedValue = dt.Rows[0]["ctrl_veiculo"].ToString();
                        ddl_status.SelectedValue = dt.Rows[0]["status"].ToString();
                        ddl_grupo.SelectedValue = dt.Rows[0]["id_grupo"].ToString();

                    }
                    else
                    {
                        clienteID = 0;

                        lbl_titulo.Text = "Cadastro de Usuários";
                        bt_salvar.Visible = true;
                        bt_atualizar.Visible = false;

                        if (Request.QueryString["Cid"] == null)
                        {

                            if (Session["Grupo"].ToString() == "Administrador")
                            {
                                Response.Redirect("UsuariosEscolheCliente.aspx");
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


                        GPSAdminBLL.ClienteBLL objCliente = new GPSAdminBLL.ClienteBLL();
                        dt = objCliente.BuscaClienteID(clienteID);

                        lbl_cliente.Text = dt.Rows[0]["razaosocial"].ToString();
                        hf_clienteID.Value = clienteID.ToString();

                        PreencheDdlFilial(clienteID);

                    }


                   


                    if (clienteID != 1)
                        tr_grupo.Visible = false;


                    



                    


                }
                catch (Exception ex)
                {
                    lbl_msg.Text = ex.Message;
                }

             


            }
		}


        private void PreencheDdlFilial(int clienteID)
        {
            GPSAdminModel.FilialModel objFilialModel = new GPSAdminModel.FilialModel();
            objFilialModel.ClienteID = clienteID;
            ddl_filial.DataValueField = "id";
            ddl_filial.DataTextField = "nome";
            GPSAdminBLL.FilialBLL objFilial = new GPSAdminBLL.FilialBLL();
            ddl_filial.DataSource = objFilial.ListarFiliaisClienteID(objFilialModel);
            ddl_filial.DataBind();
        }


        protected void bt_salvar_Click(object sender, EventArgs e)
        {
            string msg = "";
            lbl_msg.Text = "";

            try
            {

                string nome_competo = txt_nome_completo.Text.Trim().ToUpper();
                string login = txt_login.Text.Trim().ToLower();
                string email = txt_email.Text.Trim().ToLower();
                string senha = txt_senha.Text.Trim();
                string confirma_senha = txt_confirma_senha.Text.Trim();
                string id_filial = ddl_filial.SelectedValue;
                string ctrl_veiculo = ddl_ctrl_veiculo.SelectedValue;
                string status = ddl_status.SelectedValue;
                string clienteID = hf_clienteID.Value;
                string grupo = ddl_grupo.SelectedValue;

                if (nome_competo == "") { msg = "Nome Completo<br>"; }
                if (login == "") { msg += "Login<br>"; }
                if (email == "") { msg += "Email<br>"; }
                if (senha == "") { msg += "Senha<br>"; }
                if (confirma_senha == "") { msg += "Confirma Senha<br>"; }
                if (id_filial == "-1") { msg += "Filial<br>"; }
                if (ctrl_veiculo == "-1") { msg += "Visualiza todos Veículos da Filial<br>"; }
                if (status == "-1") { msg += "Status<br>"; }
                
                if (tr_grupo.Visible == true)                 
                {
                    if (grupo == "-1") { msg += "Grupo<br>"; }                    
                }
                else
                {
                    grupo = "2";
                }


                if (msg != "")
                {
                    throw new Exception("Favor, preencher os seguintes campos:<br>" + msg);
                }

                if (senha != confirma_senha)
                {
                    throw new Exception("Senhas não conferem.");
                }


                GPSAdminBLL.UsuarioBLL obj = new GPSAdminBLL.UsuarioBLL();
                obj.CadastrarUsuario(nome_competo, login, email, senha, Convert.ToInt32(id_filial), Convert.ToInt32(ctrl_veiculo), Convert.ToInt32(status), Convert.ToInt32(clienteID), Convert.ToInt32(grupo));

                lbl_msg.Text = "Login Cadastrado com sucesso";

            }catch (Exception ex)
            {
                msg = ex.Message;
                if (ex.Message.Contains("PK_Login"))
                    msg = "Login já cadastrado";
                lbl_msg.Text = msg;
            }            
        }

        public string busca;

      

                

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = "<a href='?id=" + e.Row.Cells[0].Text + "&busca="+busca+"'>" + e.Row.Cells[1].Text + "</a>";
            }
        }

        protected void bt_atualizar_Click(object sender, EventArgs e)
        {
            string msg = "";
            lbl_msg.Text = "";

            try
            {

                string id = hf_id.Value;
                string nome_competo = txt_nome_completo.Text.Trim().ToUpper();
                string login = txt_login.Text.Trim().ToLower();
                string email = txt_email.Text.Trim().ToLower();
                string senha = txt_senha.Text.Trim();
                string confirma_senha = txt_confirma_senha.Text.Trim();
                string id_filial = ddl_filial.SelectedValue;
                string ctrl_veiculo = ddl_ctrl_veiculo.SelectedValue;
                string status = ddl_status.SelectedValue;
                string grupo = ddl_grupo.SelectedValue;

                if (tr_grupo.Visible == true)
                {
                    if (grupo == "-1") { msg += "Grupo<br>"; }
                }
                else
                {
                    grupo = "2";
                }


                if (nome_competo == "") { msg = "Nome Completo<br>"; }
                if (login == "") { msg += "Login<br>"; }
                if (email == "") { msg += "Email<br>"; }
                if (senha == "") { msg += "Senha<br>"; }
                if (confirma_senha == "") { msg += "Confirma Senha<br>"; }
                if (id_filial == "-1") { msg += "Filial<br>"; }
                if (ctrl_veiculo == "-1") { msg += "Visualiza todos Veículos da Filial<br>"; }
                if (status == "-1") { msg += "Status<br>"; }

                if (msg != "")
                {
                    throw new Exception("Favor, preencher os seguintes campos:<br>" + msg);
                }

                if (senha != confirma_senha)
                {
                    throw new Exception("Senhas não conferem.");
                }

                GPSAdminBLL.UsuarioBLL obj = new GPSAdminBLL.UsuarioBLL();
                obj.AtualizarUsuario(Convert.ToInt32(id), nome_competo, login, email, senha, Convert.ToInt32(id_filial), Convert.ToInt32(ctrl_veiculo), Convert.ToInt32(status), Convert.ToInt32(grupo));

                lbl_msg.Text = "Login Atualizado com sucesso";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                if (ex.Message.Contains("PK_Login"))
                    msg = "Login já cadastrado";
                lbl_msg.Text = msg;
            }
        }
	}
}