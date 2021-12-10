using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServiceAdo.net
{
    public class EmployeeModel
    {
        public int id{ get; set; }
        public string name { get; set; }
        public int  basic_pay { get; set; }
        public DateTime start_date { get; set; }

        public char gender { get; set; }
        public double phone_number { get; set; }
        public string address { get; set; }
        public string department { get; set; }
   
     
        public float Deductions { get; set; }
        public double TaxablePay { get; set; }
        public float Income_Tax { get; set; }
        public double NetPay { get; set; }
       
    }
}