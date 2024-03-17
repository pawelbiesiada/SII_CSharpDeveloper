using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Workshop
{
    public class EmpTest
    {
        public static void Main(string[] args)
        {
            EmpTest empTest = new EmpTest();
            empTest.CalculateSalaryCollection(empTest.NewCollection());
        }


        public Employee[] NewCollection()
        {
            //var col = new Employee[5];
            //col[0] = new Secretary() { Id = 1, Name = "John" };
            //col[1] = new Programmer() { Id = 1, Name = "Adam" };
            //col[2] = new Director() { Id = 1, Name = "Anna" };
          
            var col = new Employee[]
            {
                new Secretary() { Id = 1, Name = "John" },
                new Programmer() { Id = 2, Name = "Adam" },
                new Programmer() { Id = 2, Name = "Adam" },
                new Director() { Id = 3, Name = "Anna" }
            };

            var eq = col[1].GetHashCode() == col[2].GetHashCode() && col[1].Equals(col[2]);

            var areEqual = col[1].Equals(col[2]); //business  true
            areEqual = col[1] == col[2]; // .NET              false

            return col;
        }

        public void CalculateSalaryCollection(Employee[] collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine("This object is: " + item.ToString());
                item.CalculateSalary();
                if (item is Director)
                {
                    ((Director)item).GetBonus();
                }
            }
        }
    }


    public abstract class Employee() : object
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual void CalculateSalary()
        {
            Console.WriteLine("Wypłacam dla " + Name);
        }

        public override string ToString()
        {
            return $"My name is {Name}, Id: {Id}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Employee)
            {
                var result = (Id == ((Employee)obj).Id);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }

    public class Secretary() : Employee
    {
        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("5000 zł");
        }
    }

    public class Programmer() : Employee
    {
        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("8000 zł");
        }
    }

    public class Director() : Employee
    {
        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("10000 zł");
        }

        public void GetBonus()
        {
            Console.WriteLine("Wypłacam bonus");
        }

    }

}
