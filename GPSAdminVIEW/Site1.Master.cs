using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.Data;

namespace GPSAdminVIEW
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        const string passphrase = "GpsPio@123*";

        public string decrypt(string message)
        {
            byte[] results;
            UTF8Encoding utf8 = new UTF8Encoding();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] deskey = md5.ComputeHash(utf8.GetBytes(passphrase));
            TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
            desalg.Key = deskey;
            desalg.Mode = CipherMode.ECB;
            desalg.Padding = PaddingMode.PKCS7;
            byte[] decrypt_data = Convert.FromBase64String(message);
            try
            {
                //To transform the utf binary code to md5 decrypt
                ICryptoTransform decryptor = desalg.CreateDecryptor();
                results = decryptor.TransformFinalBlock(decrypt_data, 0, decrypt_data.Length);
            }
            finally
            {
                desalg.Clear();
                md5.Clear();

            }
            //TO convert decrypted binery code to string
            return utf8.GetString(results);
        }


        public void Validacao()
        {
            if ((Request.QueryString["a"] != null && Request.QueryString["b"] != null) || (Session["a"] != null && Session["b"] != null))
            {


                try
                {
                    string usuario;
                    string senha;


                    if (Session["a"] != null && Session["b"] != null)
                    {
                        usuario = decrypt(Session["a"].ToString());
                        senha = decrypt(Session["b"].ToString());
                    }
                    else
                    {
                        usuario = decrypt(Request.QueryString["a"]);
                        senha = decrypt(Request.QueryString["b"]);
                    }



                    Session["a"] = Request.QueryString["a"];
                    Session["b"] = Request.QueryString["b"];

                    GPSAdminBLL.UsuarioBLL obj = new GPSAdminBLL.UsuarioBLL();
                    DataTable dt = obj.ValidaUsuario(usuario, senha);


                    if (dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        Session.Abandon();
                        string host = Request.Url.Host.ToLower();
                        Response.Redirect("http://" + host + "/gps");
                    }

                }
                catch (Exception)
                {
                    string host = Request.Url.Host.ToLower();
                    Session.Abandon();
                    Response.Redirect("http://" + host + "/gps");
                }


            }
            else
            {
                string host = Request.Url.Host.ToLower();
                Session.Abandon();
                Response.Redirect("http://" + host + "/gps");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Pioneira"] == null)
            {
                Response.Redirect("Default.aspx?a=1");
            }
            else
            {
                lbl_usuario.Text = Session["Nome"].ToString();
                lbl_grupo.Text = "("+Session["Grupo"].ToString()+")";
            }

        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }
}