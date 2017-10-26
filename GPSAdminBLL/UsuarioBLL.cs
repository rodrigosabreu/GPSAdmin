using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GPSAdminBLL
{
    public class UsuarioBLL
    {
        
        public DataTable ValidaUsuario(string usuario, string senha)
        {
            GPSAdminDAL.UsuarioDAL obj = new GPSAdminDAL.UsuarioDAL();
            return obj.ValidaUsuario(usuario, senha);
        }

        public void CadastrarUsuario(string nome_competo, string login, string email, string senha, int id_filial, int ctrl_veiculo, int status, int clienteID, int grupo)
        {
            GPSAdminDAL.UsuarioDAL obj = new GPSAdminDAL.UsuarioDAL();
            obj.CadastrarUsuario(nome_competo, login, email, senha, id_filial, ctrl_veiculo, status, clienteID, grupo);
        }

        public void AtualizarUsuario(int id, string nome_competo, string login, string email, string senha, int id_filial, int ctrl_veiculo, int status, int grupo)
        {
            GPSAdminDAL.UsuarioDAL obj = new GPSAdminDAL.UsuarioDAL();
            obj.AtualizarUsuario(id, nome_competo, login, email, senha, id_filial, ctrl_veiculo, status, grupo);
        }

        public DataTable PesquisaUsuario(string nome)
        {
            GPSAdminDAL.UsuarioDAL obj = new GPSAdminDAL.UsuarioDAL();
            return obj.PesquisaUsuario(nome);
        }

        public DataTable PesquisaUsuarioID(int id)
        {
            GPSAdminDAL.UsuarioDAL obj = new GPSAdminDAL.UsuarioDAL();
            return obj.PesquisaUsuarioID(id);
        }

        public DataTable Logar(string usuario, string senha)
        {
            GPSAdminDAL.UsuarioDAL obj = new GPSAdminDAL.UsuarioDAL();
            return obj.Logar(usuario,senha);
        }

        public DataTable ListarUsuarios(int clienteID)
        {
            GPSAdminDAL.UsuarioDAL obj = new GPSAdminDAL.UsuarioDAL();
            return obj.ListarUsuarios(clienteID);
        }

        public DataTable ListarUsuariosCtrlVeiculo(int clienteID)
        {
            GPSAdminDAL.UsuarioDAL obj = new GPSAdminDAL.UsuarioDAL();
            return obj.ListarUsuariosCtrlVeiculo(clienteID);
        }

        public DataTable ConsultaUsuarioCliente(int usuarioID)
        {
            GPSAdminDAL.UsuarioDAL obj = new GPSAdminDAL.UsuarioDAL();
            return obj.ConsultaUsuarioCliente(usuarioID);
        }


    }
}
