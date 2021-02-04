using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();           
        }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            bool exists = data.Any(e => e.Name == name);

            if (exists)
            {
                data.Remove(data.First(e => e.Name == name));
            }

            return exists;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(e => e.Name == name);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Employees working at Bakery {Name}:");

            foreach (Employee employee in data)
            {
                result.AppendLine(employee.ToString());
            }

            result.ToString().Trim();

            return result.ToString();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => data.Count; }
    }
}
