using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GPSAdminVIEW
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                if (!IsPostBack)
                {

                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    lbl_titulo.Text = "Ateração de Clientes";
                    bt_cadastrar.Visible = false;
                    bt_atualizar.Visible = true;
                    PreencherCampos(id);
                }
                else
                {
                    lbl_titulo.Text = "Cadastro de Clientes";
                    bt_cadastrar.Visible = true;
                    bt_atualizar.Visible = false;
                }
                
                }else{

                    if (hf_id.Value == "")
                    {
                        lbl_titulo.Text = "Cadastro de Clientes";
                        bt_cadastrar.Visible = true;
                        bt_atualizar.Visible = false;
                    }
                    else
                    {
                        lbl_titulo.Text = "Ateração de Clientes";
                        bt_cadastrar.Visible = false;
                        bt_atualizar.Visible = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                lbl_msg.Text = ex.Message;
            }
        }

        private void PreencherCampos(int id)
        {
            try
            {
                GPSAdminBLL.ClienteBLL obj = new GPSAdminBLL.ClienteBLL();
                DataTable dt = obj.BuscaClienteID(id);

                if (dt.Rows.Count > 0)
                {


                    DateTime datanasc = Convert.ToDateTime(dt.Rows[0]["datanasc"].ToString());
                    
                    
                    hf_id.Value = dt.Rows[0]["id"].ToString();
                    ddl_status.SelectedValue = dt.Rows[0]["status"].ToString();
                    txt_razaosocial.Text = dt.Rows[0]["razaosocial"].ToString();
                    txt_nomecontato.Text = dt.Rows[0]["contato"].ToString();
                    txt_rg.Text = dt.Rows[0]["rg"].ToString();
                    txt_orgaoemissor.Text = dt.Rows[0]["orgaoemissor"].ToString();
                    txt_orgaoemissoruf.Text = dt.Rows[0]["uf"].ToString();
                    //txt_datanascimento.Text = dt.Rows[0]["datanasc"].ToString().Replace(" 00:00:00", "");
                    txt_datanascimento.Text = datanasc.ToString().Replace(" 00:00:00", "");
                    txt_telefone.Text = dt.Rows[0]["telefone"].ToString();
                    txt_faxoutros.Text = dt.Rows[0]["cel"].ToString();
                    txt_email.Text = dt.Rows[0]["email"].ToString();
                    txt_endereco.Text = dt.Rows[0]["endereco"].ToString();                    
                    txt_numero.Text = dt.Rows[0]["numero"].ToString();
                    txt_complemento.Text = dt.Rows[0]["complemento"].ToString();
                    txt_bairro.Text = dt.Rows[0]["bairro"].ToString();
                    txt_cidade.Text = dt.Rows[0]["cidade"].ToString();
                    txt_cep.Text = dt.Rows[0]["cep"].ToString();
                    txt_estado.Text = dt.Rows[0]["estado"].ToString();
                    txt_cnpj.Text = dt.Rows[0]["cnpj"].ToString();
                    txt_cpf.Text = dt.Rows[0]["cpf"].ToString();

                    if (txt_cnpj.Text.Trim() == "-")
                    {
                        tr_cpf.Visible = true;
                        tr_cnpj.Visible = false;
                        rb_pf.Checked = true;
                        rb_pj.Checked = false;
                    }
                    else
                    {
                        tr_cpf.Visible = false;
                        tr_cnpj.Visible = true;
                        rb_pj.Checked = true;
                        rb_pf.Checked = false;
                    }

                }
            }
            catch (Exception ex)
            {
                lbl_msg.Text = ex.Message;
            }




        }

        protected void bt_cadastrar_Click(object sender, EventArgs e)
        {

            try
            {

                if (ValidaCampos() == false)
                {
                    
                    int status = Convert.ToInt32(ddl_status.SelectedValue);
                    string razaosocial = txt_razaosocial.Text;
                    string contato = txt_nomecontato.Text;
                    string rg = txt_rg.Text;
                    string orgaoemissor = txt_orgaoemissor.Text;
                    string uf = txt_orgaoemissoruf.Text;
                    DateTime datanasc = DateTime.Parse(txt_datanascimento.Text, new System.Globalization.CultureInfo("pt-BR"));                    
                    //string datanasc = txt_datanascimento.Text;
                    string telefone = txt_telefone.Text;
                    string cel = txt_faxoutros.Text;
                    string email = txt_email.Text;
                    string endereco = txt_endereco.Text;
                    string numero = txt_numero.Text;
                    string complmento = txt_complemento.Text;
                    string bairro = txt_bairro.Text;
                    string cidade = txt_cidade.Text;
                    string cep = txt_cep.Text;
                    string estado = txt_estado.Text;
                    string cnpj = txt_cnpj.Text;
                    string cpf = txt_cpf.Text;

                    int total;
                    string doc;

                    if (rb_pj.Checked)
                    {
                        total = ConsultaDocumento("cnpj", cnpj);
                        doc = "CNPJ";
                        cpf = "-";
                    }
                    else
                    {
                        total = ConsultaDocumento("cpf", cpf);
                        doc = "CPF";
                        cnpj = "-";
                    }


                    if (total > 0)
                    {
                        //alert(doc + " já cadastrado!");
                        lbl_msg.Text = doc + " já cadastrado!";
                    }
                    else
                    {
                        GPSAdminBLL.ClienteBLL objCli = new GPSAdminBLL.ClienteBLL();
                        objCli.InsereCliente(status, razaosocial, contato, rg, orgaoemissor, uf, datanasc, telefone, cel, email, endereco, numero, complmento, bairro, cidade, cep, estado, cnpj, cpf);

                        //alert("Cliente cadastrado com sucesso!");
                        //Response.Redirect("Clientes.aspx");
                        lbl_msg.Text = "Cliente cadastrado com sucesso!";
                        LimparCampos();

                    }
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
                if (ValidaCampos() == false)
                {
                    int id = Convert.ToInt32(hf_id.Value);
                    int status = Convert.ToInt32(ddl_status.SelectedValue);
                    string razaosocial = txt_razaosocial.Text;
                    string contato = txt_nomecontato.Text;
                    string rg = txt_rg.Text;
                    string orgaoemissor = txt_orgaoemissor.Text;
                    string uf = txt_orgaoemissoruf.Text;
                    DateTime datanasc = DateTime.Parse(txt_datanascimento.Text, new System.Globalization.CultureInfo("pt-BR"));
                    //string datanasc = txt_datanascimento.Text;
                    string telefone = txt_telefone.Text;
                    string cel = txt_faxoutros.Text;
                    string email = txt_email.Text;
                    string endereco = txt_endereco.Text;
                    string numero = txt_numero.Text;
                    string complemento = txt_complemento.Text;
                    string bairro = txt_bairro.Text;
                    string cidade = txt_cidade.Text;
                    string cep = txt_cep.Text;
                    string estado = txt_estado.Text;
                    string cnpj = txt_cnpj.Text;
                    string cpf = txt_cpf.Text;

                    int total;
                    string doc;

                    if (rb_pj.Checked)
                    {
                        total = ConsultaDocumento(id,"cnpj", cnpj);
                        doc = "CNPJ";
                        cpf = "-";
                    }
                    else
                    {
                        total = ConsultaDocumento(id, "cpf", cpf);
                        doc = "CPF";
                        cnpj = "-";
                    }


                    if (total > 0)
                    {
                        //alert(doc + " já cadastrado!");
                        lbl_msg.Text = doc + " já cadastrado!";
                    }
                    else
                    {


                        GPSAdminBLL.ClienteBLL objCli = new GPSAdminBLL.ClienteBLL();
                        objCli.AtualizaCliente(id, status, razaosocial, contato, rg, orgaoemissor, uf, datanasc, telefone, cel, email, endereco, numero, complemento, bairro, cidade, cep, estado, cnpj, cpf);


                        //alert("Cliente atualizado com sucesso!");
                        //Response.Redirect("Clientes.aspx?msg=");
                        lbl_msg.Text = "Cliente atualizado com sucesso!";
                        LimparCampos();
                    }
                    
                }


            }
            catch (Exception ex)
            {
                lbl_msg.Text = ex.Message;
            }

        }

        protected void rb_pf_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_pf.Checked)
            {
                tr_cnpj.Visible = false;
                tr_cpf.Visible = true;
                txt_cnpj.Text = "";
                txt_cpf.Text = "";
            }
        }

        protected void rb_pj_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_pj.Checked)
            {
                tr_cnpj.Visible = true;
                tr_cpf.Visible = false;
                txt_cnpj.Text = "";
                txt_cpf.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }


        private void alert(string msg)
        {            
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
            "err_msg",
            "alert('"+msg+"');",
            true);           
        }



        private void LimparCampos()
        {
            hf_id.Value = "";
            ddl_status.SelectedValue = "-1";
            txt_razaosocial.Text = "";
            txt_nomecontato.Text = "";
            txt_rg.Text = "";
            txt_orgaoemissor.Text = "";
            txt_orgaoemissoruf.Text = "";
            txt_datanascimento.Text = "";
            txt_telefone.Text = "";
            txt_faxoutros.Text = "";
            txt_email.Text = "";
            txt_endereco.Text = "";
            txt_numero.Text = "";
            txt_complemento.Text = "";
            txt_bairro.Text = "";
            txt_cidade.Text = "";
            txt_cep.Text = "";
            txt_estado.Text = "";
            txt_cnpj.Text = "";
            txt_cpf.Text = "";

            lbl_titulo.Text = "Cadastro de Clientes";
            bt_cadastrar.Visible = true;
            bt_atualizar.Visible = false;

        }

        private int ConsultaDocumento(int id, string tipo, string documento)
        {
            GPSAdminBLL.ClienteBLL obj = new GPSAdminBLL.ClienteBLL();
            DataTable dt = obj.ConsultaDocumento(id, tipo, documento);
            return Convert.ToInt32(dt.Rows[0]["total"]);
        }

        private int ConsultaDocumento(string tipo, string documento)
        {
            GPSAdminBLL.ClienteBLL obj = new GPSAdminBLL.ClienteBLL();
            DataTable dt = obj.ConsultaDocumento(tipo, documento);
            return Convert.ToInt32(dt.Rows[0]["total"]);
        }

        private bool ValidaCampos()
        {
            string msg = "";
            bool erro = false;
           
                if (ddl_status.SelectedValue == "-1")
                {
                    msg += "Status<br>";
                    erro = true;
                }

                if (txt_razaosocial.Text == "")
                {
                    msg += "Nome do Cliente<br>";
                    erro = true;
                }

                if (txt_nomecontato.Text == "")
                {
                    msg += "Nome do Contato<br>";
                    erro = true;
                }

                if (txt_rg.Text == "")
                {
                    msg += "RG<br>";
                    erro = true;
                }

                if (txt_orgaoemissor.Text == "")
                {
                    msg += "Orgão Emissor<br>";
                    erro = true;
                }

                if (txt_orgaoemissoruf.Text == "")
                {
                    msg += "Orgão Emissor UF<br>";
                    erro = true;
                }

                if (txt_datanascimento.Text == "")
                {
                    msg += "Data de Nascimento<br>";
                    erro = true;
                }

                if (txt_telefone.Text == "")
                {
                    msg += "Telefone<br>";
                    erro = true;
                }

                if (txt_faxoutros.Text == "")
                {
                    msg += "Fax/Outros<br>";
                    erro = true;
                }

                if (txt_email.Text == "")
                {
                    msg += "E-mail<br>";
                    erro = true;
                }

                if (txt_endereco.Text == "")
                {
                    msg += "Endereço<br>";
                    erro = true;
                }

                if (txt_numero.Text == "")
                {
                    msg += "Número<br>";
                    erro = true;
                }

                if (txt_bairro.Text == "")
                {
                    msg += "Bairro<br>";
                    erro = true;
                }

                if (txt_cidade.Text == "")
                {
                    msg += "Cidade<br>";
                    erro = true;
                }

                if (txt_estado.Text == "")
                {
                    msg += "Estado<br>";
                    erro = true;
                }

                if (txt_cep.Text == "")
                {
                    msg += "Cep<br>";
                    erro = true;
                }

                if (rb_pj.Checked)
                {
                    if (txt_cnpj.Text == "")
                    {
                        msg += "CNPJ<br>";
                        erro = true;
                    }
                }

                if (rb_pf.Checked)
                {
                    if (txt_cnpj.Text == "")
                    {
                        msg += "CPF<br>";
                        erro = true;
                    }
                }

                if (erro == true)
                {
                    lbl_msg.Text = "Favor, preencher os seguintes campos:<br>" + msg;
                }


            
            

            return erro;

        }


       
    }
}