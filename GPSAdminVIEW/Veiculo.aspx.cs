using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GPSAdminVIEW
{
    public partial class Veiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            



           if (!IsPostBack)
            {

                ddl_tipoveiculo.AppendDataBoundItems = true;
                ddl_tipoveiculo.Items.Insert(0, new ListItem("Selecione o veículo", "-1"));
                


                ddl_filial.AppendDataBoundItems = true;
                ddl_filial.Items.Insert(0, new ListItem("Selecione a filial", "-1"));
                

                ddl_status.AppendDataBoundItems = true;
                ddl_status.Items.Insert(0, new ListItem("Selecione o status", "-1"));


                GPSAdminBLL.FilialBLL objFilial = new GPSAdminBLL.FilialBLL();

                ddl_filial.DataValueField = "id";
                ddl_filial.DataTextField = "nome";
                ddl_filial.DataSource = objFilial.ListaFiliais();
                ddl_filial.DataBind();



                GPSAdminBLL.VeiculoBLL objVeiculo = new GPSAdminBLL.VeiculoBLL();

                ddl_tipoveiculo.DataValueField = "id";
                ddl_tipoveiculo.DataTextField = "tipo";
                ddl_tipoveiculo.DataSource = objVeiculo.BuscaTipoVeiculo();
                ddl_tipoveiculo.DataBind();

                
            }
            else
            {
                ddl_tipoveiculo.AppendDataBoundItems = false;
                ddl_filial.AppendDataBoundItems = false;
            }

                        
            

                      
            


        }



        public void BuscarVeiculoID(int cod_veiculo)
        {
            GPSAdminBLL.VeiculoBLL objVeiculo = new GPSAdminBLL.VeiculoBLL();
            DataTable dt = objVeiculo.BuscarVeiculoID(cod_veiculo);

            if (dt.Rows.Count > 0)
            {                
                txt_veiculo.Text = dt.Rows[0]["veiculo"].ToString();
                txt_descricao.Text = dt.Rows[0]["descricao"].ToString();
                txt_imagem.Text = dt.Rows[0]["nomeimagem"].ToString();
                ddl_filial.SelectedValue = dt.Rows[0]["idfilial"].ToString();
                ddl_status.SelectedValue = dt.Rows[0]["status"].ToString();
                ddl_tipoveiculo.SelectedValue = dt.Rows[0]["tipoveiculo"].ToString();
                txt_cod.Enabled = false;
                bt_buscar.Visible = false;
                bt_limpar.Visible = true;

                bt_salvar.Visible = false;
                bt_atualizar.Visible = true;
                
            }
            else
            {
                lbl_msg.Text = "Veículo não encontrado";
                txt_veiculo.Text = "";
                txt_descricao.Text = "";
                txt_imagem.Text = "";
                ddl_filial.SelectedValue = "-1";
                ddl_status.SelectedValue = "-1";
                ddl_tipoveiculo.SelectedValue = "-1";
                txt_cod.Enabled = true;
                bt_buscar.Visible = true;
                bt_limpar.Visible = false;

                bt_salvar.Visible = true;
                bt_atualizar.Visible = false;
                
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            lbl_msg.Text = "";
            try
            {

                int cod = Convert.ToInt32(txt_cod.Text);
                BuscarVeiculoID(cod);
                
            }
            catch (Exception ex)
            {

                string msg = ex.Message;

                if (msg.Contains("correct format") || msg.Contains("formato incorreto"))
                {
                    msg = "Favor, preencher o campo de busca corretamente.";
                }
                
                lbl_msg.Text = msg;
                
            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Veiculo.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {                  
            string msg = "";
            try
            {

                int cod_veiculo = Convert.ToInt32(txt_cod.Text);
                string veiculo = txt_veiculo.Text.Trim().ToUpper();
                string descricao = txt_descricao.Text.Trim();
                string imagem = txt_imagem.Text.Trim();
                string tipo_veiculo = ddl_tipoveiculo.SelectedValue;
                string status = ddl_status.SelectedValue;
                string id_filial = ddl_filial.SelectedValue;

                if (veiculo == "") { msg = "Veículo<br>"; }
                if (descricao == "") { msg += "Descrição<br>"; }
                if (imagem == "") { msg += "Imagem<br>"; }
                if (tipo_veiculo == "-1") { msg += "Tipo do veículo<br>"; }
                if (status == "-1") { msg += "Status<br>";}
                if (id_filial == "-1") { msg += "Filial<br>"; }

                if (msg != "")
                {

                    throw new Exception("Favor, preencher os seguintes campos:<br>" + msg);
                }
                GPSAdminBLL.VeiculoBLL objVeiculo = new GPSAdminBLL.VeiculoBLL();
                objVeiculo.CadastrarVeiculo(cod_veiculo, veiculo, descricao, imagem, Convert.ToInt32(tipo_veiculo), Convert.ToInt32(status), Convert.ToInt32(id_filial));

                lbl_msg.Text = "Veículo cadastrado com seucesso";
                BuscarVeiculoID(cod_veiculo);
            }
            catch (Exception ex)
            {
                
                msg = ex.Message;

                if(ex.Message.Contains("Cannot insert duplicate key in object")){
                    msg = "Veículo já cadastrado";
                }


                if (ex.Message.Contains("correct format") || ex.Message.Contains("formato incorreto"))
                {
                    msg = "Favor, preencher o campo código do veículo corretamente.";
                }
                
                
                lbl_msg.Text = msg;
            }
        }

        public void LimparCampos()
        {
            txt_cod.Text = "";
            txt_veiculo.Text = "";
            txt_descricao.Text = "";
            txt_imagem.Text = "";
            ddl_filial.SelectedValue = "-1";
            ddl_status.SelectedValue = "-1";
            ddl_tipoveiculo.SelectedValue = "-1";
            txt_cod.Enabled = true;
            bt_buscar.Visible = true;
            bt_limpar.Visible = false;

            bt_salvar.Visible = true;
            bt_atualizar.Visible = false;
        }

        protected void bt_atualizar_Click(object sender, EventArgs e)
        {

            try
            {

                int cod_veiculo = Convert.ToInt32(txt_cod.Text);
                string veiculo = txt_veiculo.Text;
                string descricao = txt_descricao.Text;
                string imagem = txt_imagem.Text;
                string tipo_veiculo = ddl_tipoveiculo.SelectedValue;
                string status = ddl_status.SelectedValue;
                string id_filial = ddl_filial.SelectedValue;

                GPSAdminBLL.VeiculoBLL objVeiculo = new GPSAdminBLL.VeiculoBLL();
                objVeiculo.AtualizarVeiculo(cod_veiculo, veiculo, descricao, imagem, Convert.ToInt32(tipo_veiculo), Convert.ToInt32(status), Convert.ToInt32(id_filial));

                lbl_msg.Text = "Veículo atualizado com seucesso";
                BuscarVeiculoID(cod_veiculo);


            }
            catch (Exception ex)
            {
                string msg;
                if (ex.Message.Contains("Cannot insert duplicate key in object"))
                {
                    msg = "Veículo já cadastrado";
                }
                else
                {
                    msg = ex.Message;
                }
                lbl_msg.Text = msg;
            }

        }

    }
}