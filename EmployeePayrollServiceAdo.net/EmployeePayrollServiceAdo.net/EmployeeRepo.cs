﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollServiceAdo.net
{
    public class EmployeeRepo
    {
        public static string connectionString = "Server=localhost;Database=student; Uid=root;Pwd=root;";
        MySqlConnection connection = new MySqlConnection(connectionString);
        public void checkConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("connection established");
                this.connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

    }
}
