using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GPSAdminBLL
{
    public class ClienteBLL
    {
        public void InsereCliente(int status, string razaosocial, string contato, string rg, string orgaoemissor, string uf, DateTime datanasc, string telefone, string cel, string email, string endereco, string complemento, string numero, string bairro, string cidade, string cep, string estado, string cnpj, string cpf)
        {
            GPSAdminDAL.ClienteDal objCli = new GPSAdminDAL.ClienteDal();
            objCli.InsereCliente(status, razaosocial, contato, rg, orgaoemissor, uf, datanasc, telefone, cel, email, endereco, numero, complemento, bairro, cidade, cep, estado, cnpj, cpf);
        }


        public DataTable BuscaCliente(string busca)
        {
            GPSAdminDAL.ClienteDal objCli = new GPSAdminDAL.ClienteDal();
            return objCli.BuscaCliente(busca);
        }

        public DataTable BuscaClienteID(int id)
        {
            GPSAdminDAL.ClienteDal objCli = new GPSAdminDAL.ClienteDal();
            return objCli.BuscaClienteID(id);
        }

        public void AtualizaCliente(int id, int status, string razaosocial, string contato, string rg, string orgaoemissor, string uf, DateTime datanasc, string telefone, string cel, string email, string endereco, string numero, string complemento, string bairro, string cidade, string cep, string estado, string cnpj, string cpf)
        {
            GPSAdminDAL.ClienteDal objCli = new GPSAdminDAL.ClienteDal();
            objCli.AtualizaCliente(id, status, razaosocial, contato, rg, orgaoemissor, uf, datanasc, telefone, cel, email, endereco, numero, complemento, bairro, cidade, cep, estado, cnpj, cpf);
        }  

        public DataTable ConsultaDocumento(string tipo, string documento)
        {
            GPSAdminDAL.ClienteDal objCli = new GPSAdminDAL.ClienteDal();
            return objCli.ConsultaDocumento(tipo, documento);
        }

        public DataTable ConsultaDocumento(int clienteID, string tipo, string documento)
        {
            GPSAdminDAL.ClienteDal objCli = new GPSAdminDAL.ClienteDal();
            return objCli.ConsultaDocumento(clienteID, tipo, documento);
        }

        public DataTable PreencheDropCliente()
        {
            GPSAdminDAL.ClienteDal objCli = new GPSAdminDAL.ClienteDal();
            return objCli.PreencheDropCliente();
        }
       
    }
}
