﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace GestionTâche
{
    public class SqlServer
    {
        SqlConnection connection;

        public SqlServer(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public bool IsConnection
        {
            get
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                } 
                return true;
            }
        }


    }
}
