using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace GPSAdminDAL
{
    public class ClienteDal
    {


        public void InsereCliente(int status, string razaosocial, string contato, string rg, string orgaoemissor, string uf, DateTime datanasc, string telefone, string cel, string email, string endereco, string complemento, string numero, string bairro, string cidade, string cep, string estado, string cnpj, string cpf)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[19];            
            p[0] = new SqlParameter("@status", status);            
            p[1] = new SqlParameter("@razaosocial", razaosocial);
            p[2] = new SqlParameter("@contato", contato);            
            p[3] = new SqlParameter("@rg", rg);
            p[4] = new SqlParameter("@orgaoemissor", orgaoemissor);
            p[5] = new SqlParameter("@uf", uf);            
            p[6] = new SqlParameter("@datanasc", datanasc);
            p[7] = new SqlParameter("@telefone", telefone);
            p[8] = new SqlParameter("@cel", cel);
            p[9] = new SqlParameter("@email", email);
            p[10] = new SqlParameter("@endereco", endereco);
            p[11] = new SqlParameter("@numero", numero);
            p[12] = new SqlParameter("@complemento", complemento);
            p[13] = new SqlParameter("@bairro", bairro);
            p[14] = new SqlParameter("@cidade", cidade);
            p[15] = new SqlParameter("@cep", cep);
            p[16] = new SqlParameter("@estado", estado);
            p[17] = new SqlParameter("@cnpj", cnpj);
            p[18] = new SqlParameter("@cpf", cpf);
            db.ExecuteNonQuery("stp_InsereCliente", p);

        }



        public DataTable BuscaCliente(string busca)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@busca", busca);
            return db.ExecuteDataSet("stp_SelecClienteFiltro", p).Tables[0];
        }


        public DataTable BuscaClienteID(int id)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id", id);
            return db.ExecuteDataSet("stp_SelecClienteID", p).Tables[0];
        }



        public void AtualizaCliente(int id, int status, string razaosocial, string contato, string rg, string orgaoemissor, string uf, DateTime datanasc, string telefone, string cel, string email, string endereco, string numero, string complemento, string bairro, string cidade, string cep, string estado, string cnpj, string cpf)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[20];
            p[0] = new SqlParameter("@status", status);
            p[1] = new SqlParameter("@razaosocial", razaosocial);
            p[2] = new SqlParameter("@contato", contato);
            p[3] = new SqlParameter("@rg", rg);
            p[4] = new SqlParameter("@orgaoemissor", orgaoemissor);
            p[5] = new SqlParameter("@uf", uf);
            p[6] = new SqlParameter("@datanasc", datanasc);
            p[7] = new SqlParameter("@telefone", telefone);
            p[8] = new SqlParameter("@cel", cel);
            p[9] = new SqlParameter("@email", email);
            p[10] = new SqlParameter("@endereco", endereco);
            p[11] = new SqlParameter("@numero", numero);
            p[12] = new SqlParameter("@complemento", complemento);
            p[13] = new SqlParameter("@bairro", bairro);
            p[14] = new SqlParameter("@cidade", cidade);
            p[15] = new SqlParameter("@cep", cep);
            p[16] = new SqlParameter("@estado", estado);
            p[17] = new SqlParameter("@cnpj", cnpj);
            p[18] = new SqlParameter("@cpf", cpf);
            p[19] = new SqlParameter("@id", id);
            db.ExecuteNonQuery("stp_AlterarCliente", p);

        }


        public DataTable ConsultaDocumento(string tipo, string documento)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@tipo", tipo);
            p[1] = new SqlParameter("@documento", documento);
            return db.ExecuteDataSet("stp_ConsultaDocumentoCliente", p).Tables[0];
        }

        public DataTable ConsultaDocumento(int clienteID, string tipo, string documento)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@id", clienteID);
            p[1] = new SqlParameter("@tipo", tipo);
            p[2] = new SqlParameter("@documento", documento);
            return db.ExecuteDataSet("stp_ConsultaDocumentoClienteID", p).Tables[0];
        }

        public DataTable PreencheDropCliente()
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[0];
            return db.ExecuteDataSet("stp_PreencheDropCliente", p).Tables[0];
        }


    }
}