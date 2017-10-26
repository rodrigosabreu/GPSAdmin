using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GPSAdminDAL
{
    public class VeiculoDAL
    {

        public DataTable BuscarVeiculoID(int cod_veiculo)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@cod_veiculo", cod_veiculo);
            return db.ExecuteDataSet("stp_SelectVeiculoID", p).Tables[0];
        }


        public DataTable BuscaTipoVeiculo()
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[0];            
            return db.ExecuteDataSet("stp_SelectTipoVeiculo", p).Tables[0];
        }

        public void CadastrarVeiculo(int cod_veiculo, string veiculo, string descricao, string imagem, int tipo_veiculo, int status, int id_filial)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@cod_veiculo", cod_veiculo);
            p[1] = new SqlParameter("@veiculo", veiculo);
            p[2] = new SqlParameter("@descricao", descricao);
            p[3] = new SqlParameter("@imagem", imagem);
            p[4] = new SqlParameter("@tipo_veiculo", tipo_veiculo);
            p[5] = new SqlParameter("@status", status);
            p[6] = new SqlParameter("@id_filial", id_filial);
            db.ExecuteNonQuery("stp_InsereVeiculo", p);
        }

        public void AtualizarVeiculo(int cod_veiculo, string veiculo, string descricao, string imagem, int tipo_veiculo, int status, int id_filial)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@cod_veiculo", cod_veiculo);
            p[1] = new SqlParameter("@veiculo", veiculo);
            p[2] = new SqlParameter("@descricao", descricao);
            p[3] = new SqlParameter("@imagem", imagem);
            p[4] = new SqlParameter("@tipo_veiculo", tipo_veiculo);
            p[5] = new SqlParameter("@status", status);
            p[6] = new SqlParameter("@id_filial", id_filial);
            db.ExecuteNonQuery("stp_AtualizaVeiculo", p);
        }

        public DataTable SelecionaVeiculosCliente(int clienteID)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@clienteID", clienteID);
            return db.ExecuteDataSet("stp_SelecionaVeiculosCliente", p).Tables[0];
        }


        public DataTable SelecionaPerfilVeiculo(int usuarioID)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@usuarioID", usuarioID);
            return db.ExecuteDataSet("stp_SelecionaPerfilVeiculo", p).Tables[0];
        }

        public void RemovePerfilVeiculo(int id_usuario)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id_usuario", id_usuario);
            db.ExecuteNonQuery("stp_RemovePerfilVeiculo", p);
        }


        public void InserePerfilVeiculo(int id_usuario, int cod_veiculo)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@id_usuario", id_usuario);
            p[1] = new SqlParameter("@cod_veiculo", cod_veiculo);
            db.ExecuteNonQuery("stp_InserePerfilVeiculo", p);
        }


    }
}
