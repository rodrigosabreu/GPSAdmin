using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPSAdminModel
{
    public class FilialModel
    {

        private int id;
        private string nome;
        private string descricao;
        private string email_grupo;
        private int status;
        private int clienteID;

       


        public int Id
        {
            get { return id; }
            set { id = value; }
        }        
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public string Email_grupo
        {
            get { return email_grupo; }
            set { email_grupo = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }        public int ClienteID
        {
            get { return clienteID; }
            set { clienteID = value; }
        }

    }
}
