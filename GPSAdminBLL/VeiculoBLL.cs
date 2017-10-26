using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GPSAdminBLL
{
    
    public class VeiculoBLL
    {

        public DataTable BuscarVeiculoID(int cod_veiculo)
        {
            GPSAdminDAL.VeiculoDAL objVeiculo = new GPSAdminDAL.VeiculoDAL();
            return objVeiculo.BuscarVeiculoID(cod_veiculo);
        }

        public DataTable BuscaTipoVeiculo()
        {
            GPSAdminDAL.VeiculoDAL objVeiculo = new GPSAdminDAL.VeiculoDAL();
            return objVeiculo.BuscaTipoVeiculo();
        }

        public void CadastrarVeiculo(int cod_veiculo, string veiculo, string descricao, string imagem, int tipo_veiculo, int status, int id_filial)
        {
            GPSAdminDAL.VeiculoDAL objVeiculo = new GPSAdminDAL.VeiculoDAL();
            objVeiculo.CadastrarVeiculo(cod_veiculo, veiculo, descricao, imagem, tipo_veiculo, status, id_filial);
        }
        public void AtualizarVeiculo(int cod_veiculo, string veiculo, string descricao, string imagem, int tipo_veiculo, int status, int id_filial)
        {
            GPSAdminDAL.VeiculoDAL objVeiculo = new GPSAdminDAL.VeiculoDAL();
            objVeiculo.AtualizarVeiculo(cod_veiculo, veiculo, descricao, imagem, tipo_veiculo, status, id_filial);
        }


        public DataTable SelecionaVeiculosCliente(int clienteID)
        {
            GPSAdminDAL.VeiculoDAL objVeiculo = new GPSAdminDAL.VeiculoDAL();
            return objVeiculo.SelecionaVeiculosCliente(clienteID);
        }


        public DataTable SelecionaPerfilVeiculo(int usuarioID)
        {
            GPSAdminDAL.VeiculoDAL objVeiculo = new GPSAdminDAL.VeiculoDAL();
            return objVeiculo.SelecionaPerfilVeiculo(usuarioID);
        }

        public void InserePerfilVeiculo(int id_usuario, int cod_veiculo)
        {
            GPSAdminDAL.VeiculoDAL objVeiculolDAL = new GPSAdminDAL.VeiculoDAL();
            objVeiculolDAL.InserePerfilVeiculo(id_usuario, cod_veiculo);

        }


        public void RemovePerfilVeiculo(int id_usuario)
        {
            GPSAdminDAL.VeiculoDAL objVeiculolDAL = new GPSAdminDAL.VeiculoDAL();
            objVeiculolDAL.RemovePerfilVeiculo(id_usuario);

        }


    }
}
