using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Channels;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine();

            //TODO: Print the Average of numbers

            Console.WriteLine($"Average: {numbers.Average()}");
            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console

            var ascendingOrder = numbers.OrderBy(num => num).ToList();
            Console.WriteLine("Ascending Order:");
            foreach (var num in ascendingOrder)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //TODO: Order numbers in descending order and print to the console

            var descendingOrder = numbers.OrderByDescending(num => num).ToList();
            Console.WriteLine("Descending Order:");
            foreach (var num in descendingOrder)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6

            var greaterThanSix = numbers.Where(num => num > 6).ToList();
            Console.WriteLine("Numbers Greater Than Six:");
            foreach (var num in greaterThanSix)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            var fourNumbers = ascendingOrder.Take(4);
            Console.WriteLine("Four Numbers From Ascending Order:");
            foreach (var num in fourNumbers)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            Console.WriteLine("Updated number list:");
            numbers.Select((number, index) => index == 4 ? 28 : number).OrderByDescending(number => number).ToList().ForEach(number => Console.WriteLine(number));
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            var filteredEmployees = employees.Where(employee => employee.FirstName.StartsWith('C') || employee.FirstName.StartsWith('S')).OrderBy(employee => employee.FirstName);
            Console.WriteLine("Employees who's name starts with C or S:");
            foreach (var emp in filteredEmployees)
            {
                Console.WriteLine(emp.FullName);
            }
            Console.WriteLine();


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            var over26 = employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName).ToList();
            Console.WriteLine("Employee full names over age 26:");
            foreach(var emp in over26)
            {
                Console.WriteLine($"{emp.FullName} is {emp.Age} years old.");
            }
            Console.WriteLine();

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var filteredYOE = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35).ToList();
            Console.WriteLine($"Sum of years of experience for employees older than 35 with less than 10 years of experience: {filteredYOE.Sum(employee => employee.YearsOfExperience)}");
            Console.WriteLine();

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine($"Average of years of experience for employees older than 35 with less than 10 years of experience: {filteredYOE.Average(employee => employee.YearsOfExperience)}");
            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()

            employees.Append(new Employee { FirstName = "Sam", LastName = "Shadwell", Age = 28, YearsOfExperience = 3 }).ToList().ForEach(employee => Console.WriteLine(employee.FullName));

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
