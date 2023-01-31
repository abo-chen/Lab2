using Lab2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //4.a
            string path = "employees.txt";
            string[] lines = File.ReadAllLines(path);


            string salariedId = "01234";
            string wagedId = "567";
            string partTimeId = "89";
            List<Employee> employees = new List<Employee>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                string id = parts[0];
                string name = parts[1];
                string address = parts[2];
                string phone = parts[3];
                long sin = long.Parse(parts[4]);
                string birthday = parts[5];
                string department = parts[6];

                if (salariedId.Contains(parts[0].Substring(0, 1)))
                {
                    double salary = double.Parse(parts[7]);
                    employees.Add(new Salaried(id, name, address, phone, sin, birthday, department, salary));
                }
                else if (wagedId.Contains(parts[0].Substring(0, 1)))
                {
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);
                    employees.Add(new Waged(id, name, address, phone, sin, birthday, department, rate, hours));
                }
                else if (partTimeId.Contains(parts[0].Substring(0, 1)))
                {
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);
                    employees.Add(new PartTime(id, name, address, phone, sin, birthday, department, rate, hours));
                }
            }

            //4.b
            double weekPaySum = 0;
            foreach (var employee in employees)
            {
                weekPaySum += employee.Pay;
            }
            Console.WriteLine($"The average weekly pay: {weekPaySum / employees.Count:C2}");

            //4.c
            double highestWage = 0;
            Employee highestEmployee = null;
            foreach (var employee in employees)
            {
                if (employee is Waged waged)
                {
                    if (waged.Pay > highestWage)
                    {
                        highestWage = employee.Pay;
                        highestEmployee = employee;
                    }
                }
            }
            Console.WriteLine($"The highest weekly pay is {highestWage:C2} for {highestEmployee.Name}");

            //4.d
            Employee lowestEmployee = findLowestSalary(employees);
            Console.WriteLine($"The lowest weekly pay is {lowestEmployee.Pay:C2} for {lowestEmployee.Name}");

            //4.e
            int salariedSum = 0;
            int wagedSum = 0;
            int partTimeSum = 0;
            foreach (var employee in employees)
            {
                if (employee is Salaried) { salariedSum++; }
                else if (employee is Waged) { wagedSum++; }
                else if (employee is PartTime) { partTimeSum++; }
            }
            Console.WriteLine($"The percentage of employees Salaried in the company: {(float)salariedSum/employees.Count*100:N2}%\n" +
                $"The percentage of employees Waged in the company:: {(float)wagedSum / employees.Count * 100:N2}%\n" +
                $"The percentage of employees PartTime in the company:: {(float)partTimeSum / employees.Count * 100:N2}%");
        }

        public static Employee findLowestSalary(List<Employee> employees)
        {
            double lowestSalary = double.MaxValue;
            Employee lowestEmployee = null;
            foreach (var employee in employees)
            {
                if (employee is Salaried salaried)
                {
                    if (salaried.Pay < lowestSalary)
                    {
                        lowestSalary = employee.Pay;
                        lowestEmployee = employee;
                    }
                }
            }
            return lowestEmployee;
        }
    }
}