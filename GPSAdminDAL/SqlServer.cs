using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GPSAdminDAL
{
    public class SqlServer
    {
        private static SqlServer instance = null;

        private SqlServer() { }

        public static SqlServer getInstance()
        {
            if (instance == null)
                instance = new SqlServer();
            return instance;
        }

        public SqlConnection getConnection()
        {
            

            //ambiente secundario
            string conn = @"Data Source =172.27.72.31; Initial Catalog=GPS; User Id=TESTE; Password=TESTE";

            

            return new SqlConnection(conn);
        }
    }
}