//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace PayslipManagementDataServices
//{
//    public class EmployeeDBData
//    {

//        private string connectionString
//            = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = PayslipManagement;Integrated Security = True; TrustServerCertificate= True ; ";


//        private SqlConnection sqlConnection;


//        public EmployeeDBData()
//        {
//              sqlConnection = new SqlConnection(connectionString);

//            sqlConnection.Open();
//        }
//    }


//}

using Microsoft.Data.SqlClient;
using payslipLibrary;
using System;
using System.Collections.Generic;

namespace PayslipManagementDataServices
{
    public class EmployeeDBData
    {
        private string connectionString
            = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=PayslipManagement;Integrated Security=True;TrustServerCertificate=True;";

        public EmployeeDBData()
        {
            // nothing to do in constructor for now
        }

        // Add employee to database
        public void AddEmployee(Employee emp)
        {
            string insertQuery = @"
                INSERT INTO Employees
                (EmployeeNumber, EmployeeName, BasicSalary, Allowances, OverTime, HolidayDays,
                 LeaveDays, DaysPresent, SSS, PhilHealth, PagIbig, PayGrade, NetSalary)
                VALUES
                (@EmployeeNumber, @EmployeeName, @BasicSalary, @Allowances, @OverTime, @HolidayDays,
                 @LeaveDays, @DaysPresent, @SSS, @PhilHealth, @PagIbig, @PayGrade, @NetSalary)";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeNumber", emp.employeeNumber);
                    cmd.Parameters.AddWithValue("@EmployeeName", emp.employeeName);
                    cmd.Parameters.AddWithValue("@BasicSalary", emp.basicSalary);
                    cmd.Parameters.AddWithValue("@Allowances", emp.allowances);
                    cmd.Parameters.AddWithValue("@OverTime", emp.overTime);
                    cmd.Parameters.AddWithValue("@HolidayDays", emp.holidayDays);
                    cmd.Parameters.AddWithValue("@LeaveDays", emp.leaveDays);
                    cmd.Parameters.AddWithValue("@DaysPresent", emp.daysPresent);
                    cmd.Parameters.AddWithValue("@SSS", emp.sss);
                    cmd.Parameters.AddWithValue("@PhilHealth", emp.philHealth);
                    cmd.Parameters.AddWithValue("@PagIbig", emp.pagIbig);
                    cmd.Parameters.AddWithValue("@PayGrade", emp.payGrade);
                    cmd.Parameters.AddWithValue("@NetSalary", emp.netSalary);

                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }

            Console.WriteLine("Employee added to database successfully!");
        }

        // Get all employees from database
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string selectQuery = "SELECT * FROM Employees";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(selectQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee emp = new Employee()
                        {
                            employeeNumber = reader["EmployeeNumber"].ToString(),
                            employeeName = reader["EmployeeName"].ToString(),
                            basicSalary = Convert.ToDouble(reader["BasicSalary"]),
                            allowances = Convert.ToDouble(reader["Allowances"]),
                            overTime = Convert.ToDouble(reader["OverTime"]),
                            holidayDays = Convert.ToInt32(reader["HolidayDays"]),
                            leaveDays = Convert.ToInt32(reader["LeaveDays"]),
                            daysPresent = Convert.ToInt32(reader["DaysPresent"]),
                            sss = Convert.ToDouble(reader["SSS"]),
                            philHealth = Convert.ToDouble(reader["PhilHealth"]),
                            pagIbig = Convert.ToDouble(reader["PagIbig"]),
                            payGrade = Convert.ToChar(reader["PayGrade"]),
                            netSalary = Convert.ToDouble(reader["NetSalary"])
                        };
                        employees.Add(emp);
                    }

                    sqlConnection.Close();
                }
            }

            return employees;
        }
    }
}

