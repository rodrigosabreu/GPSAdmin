using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSAdminVIEW
{
    public partial class Filiais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                try
                {

                    int clienteID;

                    if (Request.QueryString["Fid"] != null)
                    {
                        lbl_titulo.Text = "Alteração de Filiais";

                        int filialID = Convert.ToInt32(Request.QueryString["Fid"].ToString());
                        GPSAdminModel.FilialModel objFilialModel = new GPSAdminModel.FilialModel();
                        objFilialModel.Id = filialID;

                        GPSAdminBLL.FilialBLL objFilial = new GPSAdminBLL.FilialBLL();
                        DataTable dt = objFilial.ListarFilialID(objFilialModel);

                        lbl_cliente.Text = dt.Rows[0]["nome_cliente"].ToString();


                        //verificação caso um cliente tente acessar filial de outro cliente
                        if (Session["Grupo"].ToString() != "Administrador")
                        {
                            clienteID = Convert.ToInt32(dt.Rows[0]["id_cliente"].ToString());

                            if (clienteID != Convert.ToInt32(Session["ClienteID"].ToString()))
                            {
                                Response.Redirect("Filiais.aspx");
                            }
                        }

                        hf_clienteID.Value = dt.Rows[0]["id"].ToString();
                        ddl_status.SelectedValue = dt.Rows[0]["status"].ToString();
                        txt_nome_filial.Text = dt.Rows[0]["nome"].ToString();
                        txt_descricao.Text = dt.Rows[0]["descricao"].ToString();
                        txt_email.Text = dt.Rows[0]["email_grupo"].ToString();

                        bt_cadastrar.Visible = false;
                        bt_atualizar.Visible = true;

                    }
                    else
                    {

                        clienteID = 0;

                        lbl_titulo.Text = "Cadastro de Filiais";
                        bt_cadastrar.Visible = true;
                        bt_atualizar.Visible = false;



                        if (Request.QueryString["Cid"] == null)
                        {


                            if (Session["Grupo"].ToString() == "Administrador")
                            {
                                Response.Redirect("FiliaisEscolheCliente.aspx");
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
                        DataTable dt = objCliente.BuscaClienteID(clienteID);

                        lbl_cliente.Text = dt.Rows[0]["razaosocial"].ToString();
                        hf_clienteID.Value = clienteID.ToString();



                    }



                }
                catch (Exception ex)
                {
                    lbl_msg.Text = ex.Message;
                }
            }

        }

        protected void bt_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                GPSAdminModel.FilialModel objFilialModel = new GPSAdminModel.FilialModel();

                objFilialModel.Id = Convert.ToInt32(hf_clienteID.Value);
                objFilialModel.Status = Convert.ToInt32(ddl_status.SelectedValue);
                objFilialModel.Nome = txt_nome_filial.Text;
                objFilialModel.Descricao = txt_descricao.Text;
                objFilialModel.Email_grupo = txt_email.Text;
                objFilialModel.ClienteID = Convert.ToInt32(hf_clienteID.Value);

                GPSAdminBLL.FilialBLL obj = new GPSAdminBLL.FilialBLL();
                obj.CadastrarFilial(objFilialModel);

                lbl_msg.Text = "Filial cadastrado com sucesso!";

            }
            catch (SqlException sqlex)
            {

                if (sqlex.Message.Contains("duplicate key"))
                {
                    lbl_msg.Text = "Filial já cadastrada!";
                }
                else 
                {
                    lbl_msg.Text = sqlex.Message;
                }
            }
            catch (Exception ex)
            {
                lbl_msg.Text = ex.Message;
            }

        }

        protected void bt_atualizar_Click(object sender, EventArgs e)
        {
            try
            {

                GPSAdminModel.FilialModel objFilialModel = new GPSAdminModel.FilialModel();

                objFilialModel.Id = Convert.ToInt32(hf_clienteID.Value);
                objFilialModel.Status = Convert.ToInt32(ddl_status.SelectedValue);
                objFilialModel.Nome = txt_nome_filial.Text;
                objFilialModel.Descricao = txt_descricao.Text;
                objFilialModel.Email_grupo = txt_email.Text;
                objFilialModel.ClienteID = Convert.ToInt32(hf_clienteID.Value);

                GPSAdminBLL.FilialBLL obj = new GPSAdminBLL.FilialBLL();
                obj.AtualizarFilial(objFilialModel);

                lbl_msg.Text = "Filial atualizado com sucesso!";

            }
            catch (SqlException sqlex)
            {

                if (sqlex.Message.Contains("duplicate key"))
                {
                    lbl_msg.Text = "Filial já cadastrada!";
                }
                else
                {
                    lbl_msg.Text = sqlex.Message;
                }
            }
            catch (Exception ex)
            {
                lbl_msg.Text = ex.Message;
            }
        }

        protected void bt_limpar_Click(object sender, EventArgs e)
        {
            ddl_status.SelectedValue = "-1";
            hf_clienteID.Value = "0";
            ddl_status.SelectedValue = "";
            txt_nome_filial.Text = "";
            txt_descricao.Text = "";
            txt_email.Text = "";
        }
    }
}