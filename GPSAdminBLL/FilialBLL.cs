using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace GPSAdminBLL
{


    public class ColecaoFiliais : List<GPSAdminModel.FilialModel> { }

    public class FilialBLL
    {



        public void CadastrarFilial(GPSAdminModel.FilialModel obj)
        {
            GPSAdminDAL.FilialDAL objFilialDAL = new GPSAdminDAL.FilialDAL();
            objFilialDAL.CadastrarFilial(obj);

        }

        public void AtualizarFilial(GPSAdminModel.FilialModel obj)
        {
            GPSAdminDAL.FilialDAL objFilialDAL = new GPSAdminDAL.FilialDAL();
            objFilialDAL.AtualizarFilial(obj);

        }

        


        
        
        //metodo que seleciona dados por id da tabela Price
        public ColecaoFiliais ListaFiliais()
        {
            
            GPSAdminDAL.FilialDAL objFilialDAL = new GPSAdminDAL.FilialDAL();
            DataTable dt = objFilialDAL.ListarFiliais();
            
            ColecaoFiliais objFiliais = new ColecaoFiliais();          
            

            foreach (DataRow dtt in dt.Rows)
            {
                objFiliais.Add(AddColecaoFilial(dtt));
            }


            return objFiliais;
        }



        public GPSAdminModel.FilialModel AddColecaoFilial(DataRow dr)
        {
            GPSAdminModel.FilialModel objFilial = new GPSAdminModel.FilialModel();

            if (dr.Table.Columns.Contains("id")) objFilial.Id  = Convert.ToInt32(dr["id"]);
            if (dr.Table.Columns.Contains("nome")) objFilial.Nome = Convert.ToString(dr["nome"]);

            return objFilial;

        }



        public DataTable ListarFiliaisClienteID(GPSAdminModel.FilialModel obj)
        {
            GPSAdminDAL.FilialDAL objFilialDAL = new GPSAdminDAL.FilialDAL();
            return objFilialDAL.ListarFiliaisClienteID(obj);

        }


        public DataTable ListarFilialID(GPSAdminModel.FilialModel obj)
        {
            GPSAdminDAL.FilialDAL objFilialDAL = new GPSAdminDAL.FilialDAL();
            return objFilialDAL.ListarFilialID(obj);

        }

        public DataTable SelecionaPerfilFilial(int id_usuario)
        {
            GPSAdminDAL.FilialDAL objFilialDAL = new GPSAdminDAL.FilialDAL();
            return objFilialDAL.SelecionaPerfilFilial(id_usuario);

        }

        public void InserePerfilFilial(int id_usuario, int id_filial)
        {
            GPSAdminDAL.FilialDAL objFilialDAL = new GPSAdminDAL.FilialDAL();
            objFilialDAL.InserePerfilFilial(id_usuario, id_filial);

        }


        public void RemovePerfilFilial(int id_usuario)
        {
            GPSAdminDAL.FilialDAL objFilialDAL = new GPSAdminDAL.FilialDAL();
            objFilialDAL.RemovePerfilFilial(id_usuario);

        }


    }
}
