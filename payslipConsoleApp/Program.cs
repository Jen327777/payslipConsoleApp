

using PayslipManagementDataServices;

namespace payslipLibrary
{

    class Program
    {

        static void Main(string[] args)
        {
            Employee emp = new Employee();
            PayrollAppService p = new PayrollAppService();
            PayslipDataService dataService = new PayslipDataService();


            Console.WriteLine("===MONTHLY EMPLOYEE PAYSLIP SYSTEM===");

            Console.WriteLine("Enter name of the Employee: ");
            emp.employeeName = Console.ReadLine();


            Console.WriteLine("Enter Employee Number: ");
            emp.employeeNumber = Console.ReadLine();

            Console.WriteLine("Specify Pay Grade");
            Console.WriteLine("     ");
            Console.WriteLine(  "[A] = Manager\n" +
                                "[B] = Supervisor\n" +
                                "[C] = Staff\n" +
                                "[D] = Non - Regularized");
            Console.WriteLine("Pay Grade: ");
            emp.payGrade = Console.ReadLine().ToUpper()[0];

            Console.WriteLine("Basic Salary: ");
            emp.basicSalary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Allowances: ");
            emp.allowances = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Regular Overtime: ");
            emp.overTime = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Number of Holiday Days: ");
            emp.holidayDays = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Number of Days Leaves: ");
            emp.leaveDays = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Number of Days Present: ");
            emp.daysPresent = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Shift Duration: ");
            emp.shift = Console.ReadLine();

            Console.WriteLine("SSS Deduction: ");
            emp.sss = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Philhealth Deduction: ");
            emp.philHealth = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("PagIbig Deduction: ");
            emp.pagIbig = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("---------------------------------------- ");
            Console.WriteLine("\nEMPLOYEE " + emp.employeeNumber + " DATA\n");
            Console.WriteLine("---------------------------------------- ");
            Console.WriteLine("Employee Name: " + emp.employeeName);
            Console.WriteLine("Employee Number: " + emp.employeeNumber);
            Console.WriteLine("Pay Grade: " + emp.payGrade + " Employee Type");
            Console.WriteLine("Basic Salary: " + emp.basicSalary);
            Console.WriteLine("Allowances: " + emp.allowances);
            Console.WriteLine("Overtime: " + emp.overTime);
            Console.WriteLine("Holidays: " + emp.holidayDays + " Present Holiday.");
            Console.WriteLine("Total of Leaves: " + emp.leaveDays);
            Console.WriteLine("Number of Days Present: " + emp.daysPresent);
            Console.WriteLine("Duration of Shift: " + emp.shift);
            Console.WriteLine("SSS Deduction: " + emp.sss);
            Console.WriteLine("PhilHealth Deduction: " + emp.philHealth);
            Console.WriteLine("PagIbig Deduction: " + emp.pagIbig);
            Console.WriteLine("   ");
            Console.WriteLine("   ");

            p.calculator(emp);
            dataService.SaveInfo(emp, emp.netSalary);
            dataService.displayPayslipList();








        }
    }
}