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
        private readonly payslipJSONData _jsonData;

        public PayslipDataService()
        {
            _jsonData = new payslipJSONData();
        }

        public void SaveInfo(Employee e)
        {
            _jsonData.EmployeeList.Add(e);   // add to JSON list
            _jsonData.SaveData();            // save to file

            Console.WriteLine("\nSuccessfully added employee information to the payslip record.");
        }

        public void DisplayPayslipList()
        {
            Console.WriteLine("===LIST OF EMPLOYEES IN THE PAYSLIP RECORD===");
            foreach (var e in _jsonData.EmployeeList)
            {
                Console.WriteLine(
                    "Employee Name: " + e.employeeName +
                    "\nEmployee Number: " + e.employeeNumber +
                    "\nBasic Salary: "   + e.basicSalary.ToString("F2")  +
                    "\nAllowances: "     + e.allowances.ToString("F2") +
                    "\nOvertime: " + e.overTime.ToString("F2") +
                    "\nHoliday Days: " + e.holidayDays +
                    "\nLeave Days: " + e.leaveDays +
                    "\nDays Present: "   + e.daysPresent +
                    "\nSSS: " + e.sss.ToString("F2") +
                    "\nPhilHealth: " + e.philHealth.ToString("F2") +
                    "\nPag-IBIG: " + e.pagIbig.ToString("F2") +
                    "\nPay Grade: " + e.payGrade +
                    "\nNet Salary: " + e.netSalary.ToString("F2") +
                    
                    "\n=============================================");
            }
        }
    }
}