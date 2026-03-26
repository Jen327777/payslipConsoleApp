using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayslipManagementDataServices
{
    public class EmployeeDBData
    {

        private string connectionString
            = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = PayslipManagement;Integrated Security = True; TrustServerCertificate= True ; ";


        private SqlConnection sqlConnection;


        public EmployeeDBData()
        {
              sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();
        }
    }

   
}
