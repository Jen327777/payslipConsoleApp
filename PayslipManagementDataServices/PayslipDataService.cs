//using payslipLibrary;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace PayslipManagementDataServices
//{
//         public class PayslipDataService{

//        public List<Employee> payslipRec = new List<Employee>();

//        public PayslipDataService()
//        {
//            payslipJSONData jsonData = new payslipJSONData();
//        }


//        public void SaveInfo(Employee e, double netSalary)
//        {
//            e.netSalary = netSalary;
//            payslipRec.Add(e);

//            Console.WriteLine( "                                              " +
//                "\n --------------------------------------------------------");

//            Console.WriteLine("\nSuccessfully added employee information to the payslip record."); ;

//            // amethodor function to save employee infos to payslip record
//        }

//        public void displayPayslipList()
//        {
//            // amethod to display the list of saved payslip records

//            Console.WriteLine ("===LIST OF EMPLOYEES IN THE PAYSLIP RECORD===");

//            foreach(Employee e in payslipRec)
//            {
//                Console.WriteLine(
//                    "Employee Name: " + e.employeeName +
//                    "\nEmployee Number: " + e.employeeNumber +
//                    "\nShift Hours: " + e.shift +
//                    "\nNet Salary: " + e.netSalary.ToString("F2")
//                + "\n =============================================");

//            }


//        }


//}




//    }

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
            _jsonData.EmployeeList.Add(emp);   // add to JSON list
            _jsonData.SaveData();            // save to file

            Console.WriteLine("\nSuccessfully added employee information to the payslip record.");
        }

        public void DisplayPayslipList()
        {
            Console.WriteLine("\n--------------------------------------------------------\n");

            Console.WriteLine("===LIST OF EMPLOYEES IN THE PAYSLIP RECORD===\n");
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
                    "\nDays Present: "   + emp.daysPresent +
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