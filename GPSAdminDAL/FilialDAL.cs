using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GPSAdminDAL
{
    public class FilialDAL
    {

        public void CadastrarFilial(GPSAdminModel.FilialModel obj)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@nome_filial", obj.Nome);
            p[1] = new SqlParameter("@descricao", obj.Descricao);
            p[2] = new SqlParameter("@email", obj.Email_grupo);
            p[3] = new SqlParameter("@status", obj.Status);
            p[4] = new SqlParameter("@clienteID", obj.ClienteID);
            db.ExecuteNonQuery("stp_InsereFilial", p);
        
        }


        public void AtualizarFilial(GPSAdminModel.FilialModel obj)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@id", obj.Id);
            p[1] = new SqlParameter("@nome_filial", obj.Nome);
            p[2] = new SqlParameter("@descricao", obj.Descricao);
            p[3] = new SqlParameter("@email", obj.Email_grupo);
            p[4] = new SqlParameter("@status", obj.Status);
            p[5] = new SqlParameter("@clienteID", obj.ClienteID);
            db.ExecuteNonQuery("stp_AtualizaFilial", p);
        }


        public DataTable ListarFiliais()
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[0];
            return db.ExecuteDataSet("stp_SelectFiliaisVeiculos", p).Tables[0];
        }

        public DataTable ListarFiliaisClienteID(GPSAdminModel.FilialModel obj)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@clienteID", obj.ClienteID);
            return db.ExecuteDataSet("stp_SelectFiliaisClienteID", p).Tables[0];
        }


        public DataTable ListarFilialID(GPSAdminModel.FilialModel obj)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@filialID", obj.Id);
            return db.ExecuteDataSet("stp_SelectFilialID", p).Tables[0];
        }

        public DataTable SelecionaPerfilFilial(int id_usuario)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id_usuario", id_usuario);
            return db.ExecuteDataSet("stp_SelecionaPerfilFilial", p).Tables[0];
        }

        public void InserePerfilFilial(int id_usuario, int id_filial)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@id_usuario", id_usuario);
            p[1] = new SqlParameter("@id_filial", id_filial);
            db.ExecuteNonQuery("stp_InserePerfilFilial", p);
        }

        public void RemovePerfilFilial(int id_usuario)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id_usuario", id_usuario);            
            db.ExecuteNonQuery("stp_RemovePerfilFilial", p);
        }

    }
}
