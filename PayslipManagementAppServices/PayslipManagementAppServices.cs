using payslipLibrary;
using System;
using System.Reflection.Metadata.Ecma335;


namespace payslipLibrary
{



    public class PayrollAppService
    {

        
        public void calculator(Employee emp)
        {

            
               


            double dailyRate = emp.basicSalary / 22;
            double leaveDeduction = dailyRate * emp.leaveDays;
            double holidayPay = dailyRate * emp.holidayDays;
            double grossSalary = (dailyRate * emp.daysPresent) + holidayPay + emp.allowances + emp.overTime - leaveDeduction; //without deduction salary


            double bonusPayGrade = 0;
            switch (emp.payGrade)
            {
                case 'A':
                    bonusPayGrade = 5000;

                    break;
                case 'B':
                    bonusPayGrade = 3000;

                    break;
                case 'C':
                    bonusPayGrade = 1000;

                    break;
                case 'D':
                    bonusPayGrade = 0;

                    break;
                default:
                    Console.WriteLine("Invalid paygrade. Try again...");

                    break;


            }
            grossSalary += bonusPayGrade;

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


            emp.netSalary = taxableIncome - incomeTax;


            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Paygrade Bonus: " + bonusPayGrade);
            Console.WriteLine("Gross Salary: " + grossSalary.ToString("F2"));
            Console.WriteLine("Total Deductions: " + (emp.sss + emp.philHealth + emp.pagIbig));
            Console.WriteLine("Income Tax: " + incomeTax.ToString("F2"));
            Console.WriteLine("Net Salary: " + emp.netSalary.ToString("F2"));

        }
       


    }

}

