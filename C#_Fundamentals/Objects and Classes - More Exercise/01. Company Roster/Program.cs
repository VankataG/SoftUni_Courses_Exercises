using System.Globalization;

namespace _01._Company_Roster
{
    internal class Program
    {
        class Employee
        {
            public string Name { get; set; }
            public double Salary { get; set; }
            public string Department { get; set; }

            public Employee(string name, double salary, string department)
            {
                Name = name;
                Salary = salary;
                Department = department;
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, List<Employee>> employees = new();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];
                Employee employee = new Employee(name, salary, department);
                if (!employees.ContainsKey(department))
                {
                    employees[department] = new();
                }
                employees[department].Add(employee);
            }
            string highestD = default;
            double highestSum = 0;
            foreach ((string depatment, List<Employee> employee) in employees)
            {
                double sum = employee.Average(x => x.Salary);
                if (sum > highestSum)
                {
                    highestSum = sum;
                    highestD = depatment;
                }
            }
            Console.WriteLine($"Highest Average Salary: {highestD}");
            foreach (Employee employee in employees[highestD].OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }

        }
    }
}
