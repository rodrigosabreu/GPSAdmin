using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPSAdminModel
{
    public class VeiculoModel
    {

        private int id;
        private string veiculo;
        private string descricao;
        private int idfilial;
        private int status;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string Veiculo1
        {
            get { return veiculo; }
            set { veiculo = value; }
        }        

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }        

        public int Idfilial
        {
            get { return idfilial; }
            set { idfilial = value; }
        }       

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

    }

}