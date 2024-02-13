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
                VectorByte vector1 = new VectorByte();
                VectorByte vector2 = new VectorByte(3);
                VectorByte vector3 = new VectorByte(3, 42);

                Console.WriteLine($"Number of vectors: {VectorByte.NumVectors()}");

                vector2.InputElements();

                vector2.PrintElements();

                vector3.SetElements(99);

                vector3.PrintElements();

                Console.WriteLine("Testing Unary Operations:");
                Console.WriteLine($"Original Vector 1: {vector1[0]}");
                vector1++;
                Console.WriteLine($"After ++ operation: {vector1[0]}");
                vector1--;
                Console.WriteLine($"After -- operation: {vector1[0]}");

                Console.WriteLine($"Vector 3 is not empty: {!vector3}");

                Console.WriteLine("Testing Bitwise NOT Operator:");
                Console.WriteLine("Original Vector 2:");
                vector2.PrintElements();
                VectorByte notVector2 = ~vector2;
                Console.WriteLine("After ~ operation:");
                notVector2.PrintElements();

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

        static void Task3()
        {
            MatrixByte mat1 = new MatrixByte();
            Console.WriteLine("Default Matrix:");
            mat1.PrintElements();
            Console.WriteLine();

            MatrixByte mat2 = new MatrixByte(3, 3, 5);
            Console.WriteLine("Parameterized Matrix (all elements initialized to 5):");
            mat2.PrintElements();
            Console.WriteLine();

            MatrixByte mat3 = new MatrixByte(2, 2);
            Console.WriteLine("Enter elements for Matrix 3:");
            mat3.InputElements();
            Console.WriteLine("Matrix 3:");
            mat3.PrintElements();
            Console.WriteLine();

            Console.WriteLine("Matrix 3 after incrementing (++):");
            ++mat3;
            mat3.PrintElements();
            Console.WriteLine();

            Console.WriteLine("Matrix 3 after decrementing (--):");
            --mat3;
            mat3.PrintElements();
            Console.WriteLine();

            Console.WriteLine("Is Matrix 3 true? " + (mat3 ? "Yes" : "No"));
            Console.WriteLine("Is Matrix 3 false? " + (!mat3 ? "No" : "Yes"));

            Console.WriteLine("Logical NOT (!) Matrix 3:");
            Console.WriteLine(!mat3);
            Console.WriteLine();

            Console.WriteLine("Bitwise NOT (~) Matrix 3:");
            (~mat3).PrintElements();
            Console.WriteLine();

            MatrixByte mat4 = new MatrixByte(2, 2, 3);
            Console.WriteLine("Matrix 4 (all elements initialized to 3):");
            mat4.PrintElements();

            Console.WriteLine("Matrix 3 + Matrix 4:");
            MatrixByte mat5 = mat3 + mat4;
            mat5.PrintElements();
            Console.WriteLine();

            Console.WriteLine("Matrix 3 - Matrix 4:");
            (mat3 - mat4).PrintElements();
            Console.WriteLine();

            Console.WriteLine("Matrix 3 * Matrix 4:");
            (mat3 * mat4).PrintElements();
            Console.WriteLine();

            Console.WriteLine("Matrix 3 / Matrix 4:");
            (mat3 / mat4).PrintElements();
            Console.WriteLine();

            Console.WriteLine("Matrix 3 % Matrix 4:");
            (mat3 % mat4).PrintElements();
            Console.WriteLine();

            Console.WriteLine("Is Matrix 3 equal to Matrix 4? " + (mat3 == mat4));
            Console.WriteLine("Is Matrix 3 not equal to Matrix 4? " + (mat3 != mat4));
            Console.WriteLine("Is Matrix 3 greater than Matrix 4? " + (mat3 > mat4));
            Console.WriteLine("Is Matrix 3 greater than or equal to Matrix 4? " + (mat3 >= mat4));
            Console.WriteLine("Is Matrix 3 less than Matrix 4? " + (mat3 < mat4));
            Console.WriteLine("Is Matrix 3 less than or equal to Matrix 4? " + (mat3 <= mat4));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Lab 4 CSharp");

            while (true)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine("Select a task:");
                Console.WriteLine("1. Task 1");
                Console.WriteLine("2. Task 2");
                Console.WriteLine("3. Task 3");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=========================================================");
                Console.Write("Enter your choice >>> ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1();
                        break;

                    case "2":
                        Task2();
                        break;

                    case "3":
                        Task3();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
