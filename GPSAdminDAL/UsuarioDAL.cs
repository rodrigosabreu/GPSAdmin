using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GPSAdminDAL
{
    public class UsuarioDAL
    {

        public DataTable ValidaUsuario(string usuario, string senha)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@usuario", usuario);
            p[1] = new SqlParameter("@senha", senha);
            return db.ExecuteDataSet("stp_SelectLoginAdmin", p).Tables[0];
        }

        public DataTable PesquisaUsuario(string nome)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@nome", nome);            
            return db.ExecuteDataSet("stp_PesquisaUsuario", p).Tables[0];
        }

        public DataTable PesquisaUsuarioID(int id)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id", id);
            return db.ExecuteDataSet("stp_SelectUsuarioID", p).Tables[0];
        }


        public void CadastrarUsuario(string nome_competo, string login, string email, string senha, int id_filial, int ctrl_veiculo, int status, int clienteID, int grupo)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@nome_competo", nome_competo);
            p[1] = new SqlParameter("@login", login);
            p[2] = new SqlParameter("@email", email);
            p[3] = new SqlParameter("@senha", senha);
            p[4] = new SqlParameter("@id_filial", id_filial);
            p[5] = new SqlParameter("@ctrl_veiculo", ctrl_veiculo);
            p[6] = new SqlParameter("@status", status);
            p[7] = new SqlParameter("@clienteID", clienteID);
            p[8] = new SqlParameter("@grupo", grupo);

            db.ExecuteNonQuery("stp_InsereUsuario",p);

        }

        public void AtualizarUsuario(int id, string nome_competo, string login, string email, string senha, int id_filial, int ctrl_veiculo, int status, int grupo)
        {

            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@id", id);
            p[1] = new SqlParameter("@nome_competo", nome_competo);
            p[2] = new SqlParameter("@login", login);
            p[3] = new SqlParameter("@email", email);
            p[4] = new SqlParameter("@senha", senha);
            p[5] = new SqlParameter("@id_filial", id_filial);
            p[6] = new SqlParameter("@ctrl_veiculo", ctrl_veiculo);
            p[7] = new SqlParameter("@status", status);
            p[8] = new SqlParameter("@grupo", grupo);

            db.ExecuteNonQuery("stp_AtualizaUsuario", p);

        }

        public DataTable Logar(string usuario, string senha)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@usuario", usuario);
            p[1] = new SqlParameter("@senha", senha);
            return db.ExecuteDataSet("stp_logarADM", p).Tables[0];
        }

        public DataTable ListarUsuarios(int clienteID)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@clienteID", clienteID);
            return db.ExecuteDataSet("stp_ListarUsuariosClienteID", p).Tables[0];
        }

        public DataTable ListarUsuariosCtrlVeiculo(int clienteID)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@clienteID", clienteID);
            return db.ExecuteDataSet("stp_ListarUsuariosCtrlVeiculoClienteID", p).Tables[0];
        }

        public DataTable ConsultaUsuarioCliente(int usuarioID)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@usuarioID", usuarioID);
            return db.ExecuteDataSet("stp_ConsultaUsuarioCliente", p).Tables[0];
        } 

    }
}
