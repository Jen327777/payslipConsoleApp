

using System;
using System.Collections.Generic;
using payslipLibrary;

namespace PayslipManagementDataServices
{
    public class PayslipDataService
    {

      
        payslipJSONData _jsonData;

        public PayslipDataService()
        {
            EmployeeDBData dbData = new EmployeeDBData();
            _jsonData = new payslipJSONData();
        }

        public void SaveInfo(Employee emp)
        {
            _jsonData.EmployeeList.Add(emp);
            _jsonData.SaveData();

            Console.WriteLine("\nSuccessfully added employee information to the payslip record.");
        }
        public List<Employee> GetEmployeeList()
        {
            return _jsonData.EmployeeList;
        }

        public void DisplayPayslipList()
        {
            Console.WriteLine("\n--------------------------------------------------------\n" +
                "                                                                           "                          );

            Console.WriteLine("===LIST OF EMPLOYEES IN THE PAYSLIP RECORD===\n"
                + "                                                              ");
            Console.WriteLine("*listed below are the existing employees data\n" +
            "                                                                       ");


            foreach (var emp in _jsonData.EmployeeList)
            {
                Console.WriteLine(
                    "Employee Name: " + emp.employeeName +
                    "\nEmployee Number: " + emp.employeeNumber +
                    "\nBasic Salary: "   + emp.basicSalary.ToString("F2")  +
                    "\nAllowances: "     + emp.allowances.ToString("F2") +
                    "\nOvertime: " + emp.overTime.ToString("F2") +
                    "\nHoliday Days: " + emp.holidayDays +
                    "\nLeave Days: " + emp.leaveDays +
                    "\nDays Present: " + emp.daysPresent +
                    "\nSSS: " + emp.sss.ToString("F2") +
                    "\nPhilHealth: " + emp.philHealth.ToString("F2") +
                    "\nPag-IBIG: " + emp.pagIbig.ToString("F2") +
                    "\nPay Grade: " + emp.payGrade +
                    "\nNet Salary: " + emp.netSalary.ToString("F2") +
                    
                    "\n=============================================");
            }
        }
    }
}