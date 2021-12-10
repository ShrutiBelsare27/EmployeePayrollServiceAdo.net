using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollServiceAdo.net
{
    public class EmployeeRepo
    {
        public static string connectionString = "Server=localhost;Database=payroll_service; Uid=root;Pwd=root;";
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
        public void getAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * from employee_payroll; ";
                    MySqlCommand cmd = new MySqlCommand(query, this.connection);
                    this.connection.Open();
                    MySqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.id = sqlDataReader.GetInt32(0);
                            employeeModel.name = sqlDataReader.GetString(1);
                            employeeModel.basic_pay = sqlDataReader.GetInt32(2);
                            employeeModel.start_date = sqlDataReader.GetDateTime(3);
                            employeeModel.gender = Convert.ToChar(sqlDataReader.GetString(4));
                            employeeModel.phone_number = sqlDataReader.GetDouble(5);
                            employeeModel.department = sqlDataReader.GetString(6);
                            employeeModel.address = sqlDataReader.GetString(7);
                            employeeModel.Deductions = (sqlDataReader.GetFloat(8));
                            employeeModel.TaxablePay = Convert.ToDouble(sqlDataReader.GetFloat(9));
                            employeeModel.Income_Tax = sqlDataReader.GetFloat(10);
                            employeeModel.NetPay = Convert.ToDouble(sqlDataReader.GetFloat(11));
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", employeeModel.id, employeeModel.name ,
                                employeeModel.basic_pay,employeeModel.start_date ,employeeModel.gender,
                                employeeModel.phone_number,  employeeModel.department,  employeeModel.address,
                                employeeModel.Deductions, employeeModel.TaxablePay, employeeModel.Income_Tax,
                                employeeModel.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
           }
        }


       
    }
}
