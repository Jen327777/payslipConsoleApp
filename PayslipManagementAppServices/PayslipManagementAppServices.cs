using payslipLibrary;
using System;


namespace payslipLibrary
{



    public class PayrollAppService
    {


        public void calculator(Employee emp)
        {
            double dailyRate = emp.basicSalary / 22;
            double holidayPay = dailyRate * emp.holidayDays;
            double grossSalary = (dailyRate * emp.daysPresent) + holidayPay + emp.allowances + emp.overTime; //without deduction salary
            double taxableIncome = grossSalary - emp.sss - emp.philHealth - emp.pagIbig; //deducted salary for tax calc

            double incomeTax = 0;

            if (taxableIncome <= 20833)
                incomeTax = 0;
            else if (taxableIncome <= 33333)
                incomeTax = (taxableIncome - 20833) * 0.15;
            else if (taxableIncome <= 66667)
                incomeTax = (taxableIncome - 20833) * 0.20;
            else if (taxableIncome <= 166667)
                incomeTax = (taxableIncome - 20833) * 0.25;
            else if (taxableIncome <= 666667)
                incomeTax = (taxableIncome - 20833) * 0.30;
            else
                incomeTax = (taxableIncome - 20833) * 0.35;


            double netSalary = taxableIncome - incomeTax;


            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Gross Salary: " + grossSalary);
            Console.WriteLine("Total Deductions: " + (emp.sss + emp.philHealth + emp.pagIbig));
            Console.WriteLine("Income Tax: " + incomeTax);
            Console.WriteLine("Net Salary: " + netSalary);

        }
    }



}

