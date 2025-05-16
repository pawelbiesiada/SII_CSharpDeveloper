using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.SOLID.SOLID_Problem
{
    public enum EmployeeType
    {
        FullTime,
        Contractor,
        Robot,
        Manager
    }

    public interface IEmployeeActions
    {
        void Work();
        void AttendMeeting();
        void SubmitTimesheet();
    }


    public class Employee : IEmployeeActions
    {
        public string Name { get; set; }
        public virtual EmployeeType Type => EmployeeType.FullTime;

        public virtual void Work()
        {
            Console.WriteLine($"Worker {Name} is working.");
        }

        public virtual void AttendMeeting()
        {
            Console.WriteLine($"Worker {Name} is attending a meeting.");
        }

        public virtual void SubmitTimesheet()
        {
            Console.WriteLine($"Worker {Name} is submitting timesheet.");
        }
    }
    public class Contractor : Employee //Liskov vulnerability - inherited class changes logic, throws exception
    {
        public override EmployeeType Type => EmployeeType.Contractor;
        public override void Work()
        {
            Console.WriteLine($"Contractor {Name} is working.");
        }
        public override void AttendMeeting()
        {
            // Contractors shouldn't attend meetings
            throw new NotSupportedException("Contractors do not attend meetings.");
        }

        public override void SubmitTimesheet()
        {
            Console.WriteLine($"Contractor {Name} is submitting timesheet (contractor version).");
        }
    }

    public class Robot : Employee //Robot uses and implements unused methods - Interfaces Separation needed! Also Liskov vulnerability
    {
        public override EmployeeType Type => EmployeeType.Robot;
        public override void Work() => Console.WriteLine("Robot assembling parts.");

        public override void AttendMeeting() =>
            throw new NotImplementedException("Robots do not attend meetings.");

        public override void SubmitTimesheet() =>
            throw new NotImplementedException("Robots do not submit timesheets.");
    }

    //SRP? No, class does everything.
    //OCP? No, adding employe type requires changes.
    //DIP? No, Generation depends on low-level write logic
    //Liskov? No, code "asks" for type, so logic can depend on it...
    public class ReportGenerator 
    {
        public void GenerateReport(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                //Version 1 - we will have trouble during code work.
                employee.AttendMeeting();
                employee.Work();

                //Version 2 - we violates Liskov here, code depends of type (and it's obviously not OCP)
                //if (employee.Type == EmployeeType.FullTime)
                //{
                //    employee.AttendMeeting();
                //    employee.Work();
                //}
                //else if (employee.Type == EmployeeType.Contractor)
                //{
                //    employee.Work();
                //}
            }

            Console.WriteLine("Generating report...");
        }
    }
}
