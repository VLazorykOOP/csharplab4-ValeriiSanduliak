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

        static void Task2()
        {
            try
            {
                // Vectors using different constructors
                VectorByte vector1 = new VectorByte();
                VectorByte vector2 = new VectorByte(3);
                VectorByte vector3 = new VectorByte(3, 42);

                // Number of vectors
                Console.WriteLine($"Number of vectors: {VectorByte.NumVectors()}");

                // Inputting elements for the second vector
                vector2.InputElements();

                // Printing elements of the second vector
                vector2.PrintElements();

                // Setting all elements of the third vector to 99
                vector3.SetElements(99);

                // Printing elements of the third vector
                vector3.PrintElements();

                // Testing unary operations
                Console.WriteLine("Testing Unary Operations:");
                Console.WriteLine($"Original Vector 1: {vector1[0]}");
                vector1++;
                Console.WriteLine($"After ++ operation: {vector1[0]}");
                vector1--;
                Console.WriteLine($"After -- operation: {vector1[0]}");

                // Testing logical NOT operator
                Console.WriteLine($"Vector 3 is not empty: {!vector3}");

                // Testing bitwise NOT operator
                Console.WriteLine("Testing Bitwise NOT Operator:");
                Console.WriteLine("Original Vector 2:");
                vector2.PrintElements();
                VectorByte notVector2 = ~vector2;
                Console.WriteLine("After ~ operation:");
                notVector2.PrintElements();

                // Testing binary operations
                Console.WriteLine("Testing Binary Operations:");

                Console.WriteLine("Vector 2 + Vector 3:");
                VectorByte sumVector = vector2 + vector3;
                sumVector.PrintElements();

                Console.WriteLine("Vector 3 - Vector 2:");
                VectorByte subVector = vector3 - vector2;
                subVector.PrintElements();

                Console.WriteLine("Vector 2 * Vector 3:");
                VectorByte mulVector = vector2 * vector3;
                mulVector.PrintElements();

                Console.WriteLine("Vector 3 / Vector 2:");
                VectorByte divVector = vector3 / vector2;
                divVector.PrintElements();

                Console.WriteLine("Vector 3 % Vector 2:");
                VectorByte modVector = vector3 % vector2;
                modVector.PrintElements();

                Console.WriteLine("Vector 2 | Vector 3:");
                VectorByte orVector = vector2 | vector3;
                orVector.PrintElements();

                Console.WriteLine("Vector 2 ^ Vector 3:");
                VectorByte xorVector = vector2 ^ vector3;
                xorVector.PrintElements();

                Console.WriteLine("Vector 2 & Vector 3:");
                VectorByte andVector = vector2 & vector3;
                andVector.PrintElements();

                Console.WriteLine("Vector 2 >> 1:");
                VectorByte rightShiftVector = vector2 >> 1;
                rightShiftVector.PrintElements();

                Console.WriteLine("Vector 3 << 2:");
                VectorByte leftShiftVector = vector3 << 2;
                leftShiftVector.PrintElements();

                // Testing comparison operators
                Console.WriteLine("Testing Comparison Operators:");

                Console.WriteLine($"Vector 2 == Vector 3: {vector2 == vector3}");

                Console.WriteLine($"Vector 2 != Vector 3: {vector2 != vector3}");

                Console.WriteLine($"Vector 2 > Vector 3: {vector2 > vector3}");

                Console.WriteLine($"Vector 2 >= Vector 3: {vector2 >= vector3}");

                Console.WriteLine($"Vector 2 < Vector 3: {vector2 < vector3}");

                Console.WriteLine($"Vector 2 <= Vector 3: {vector2 <= vector3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            // Task1();
            Task2();
        }
    }
}
