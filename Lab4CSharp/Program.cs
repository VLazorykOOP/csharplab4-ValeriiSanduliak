using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Lab4CSharp
{
    public class Program
    {
        static void Task1()
        {
            Date currentDate = new Date(13, 2, 2024);
            Date previousDate = currentDate[-1];
            Date nextDate = currentDate[1];

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Current date:");
            currentDate.PrintDateInMonthFormat();

            Console.WriteLine("Previous date:");
            previousDate.PrintDateInMonthFormat();

            Console.WriteLine("Next date:");
            nextDate.PrintDateInMonthFormat();
            Console.WriteLine("------------------------------------------------");

            Date currentDate1 = new Date(28, 2, 2024);
            Console.WriteLine(currentDate1 + " not the last day of the month?: " + !currentDate1);
            Console.WriteLine("------------------------------------------------");

            Date currentDate2 = new Date(1, 1, 2024);
            Console.Write(currentDate2 + " is the beginning of the year?: ");
            if (currentDate2)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.WriteLine("------------------------------------------------");
            Date date1 = new Date(13, 2, 2024);
            Date date2 = new Date(13, 2, 2024);
            Date date3 = new Date(14, 2, 2024);
            Console.WriteLine("Date1: " + date1);
            Console.WriteLine("Date2: " + date2);
            Console.WriteLine("Date3: " + date3);
            if (date1 & date2)
            {
                Console.WriteLine("Object date1 and date2 equals");
            }
            else
            {
                Console.WriteLine("Objects date1 and date2 are not equal");
            }

            if (date1 & date3)
            {
                Console.WriteLine("Object date1 and date3 equals");
            }
            else
            {
                Console.WriteLine("Objects date1 and date3 are not equal");
            }
            Console.WriteLine("------------------------------------------------");
            Date date = new Date(13, 2, 2024);
            string dateString = date;
            Console.WriteLine("Date as string: " + dateString);

            string inputString = "25.12.2023";
            Date convertedDate = inputString;
            Console.WriteLine("String converted to Date: " + convertedDate);
            Console.WriteLine("------------------------------------------------");
        }

        static void Main(string[] args)
        {
            Task1();
        }
    }
}
