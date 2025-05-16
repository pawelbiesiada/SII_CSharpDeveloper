using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.SOLID.SOLID_Problem
{
    public interface IWorker
    {
        void Work();
        EmployeeType Type { get; }
    }
  
    public interface IPayable
    {
        void SubmitTimesheet();
    }

    public class SOLIDEmployee : IWorker, IPayable
    {
        public string Name { get; set; }
        public virtual EmployeeType Type => EmployeeType.FullTime;

        public virtual void Work()
        {
            AttendMeeting();
            Console.WriteLine($"Worker {Name} is working.");
        }

        protected virtual void AttendMeeting()
        {
            Console.WriteLine($"Worker {Name} is attending a meeting.");
        }

        public virtual void SubmitTimesheet()
        {
            Console.WriteLine($"Worker {Name} is submitting timesheet.");
        }
    }

    public class SOLIDContractor : SOLIDEmployee //Liskov vulnerability - inherited class changes logic, throws exception
    {
        public override EmployeeType Type => EmployeeType.Contractor;
        public override void Work()
        {
            Console.WriteLine($"Contractor {Name} is working.");
        }       
        public override void SubmitTimesheet()
        {
            Console.WriteLine($"Contractor {Name} is submitting timesheet (contractor version).");
        }
    }

    public class SOLIDRobot : IWorker // Implements only needed functions
    {
        public EmployeeType Type => EmployeeType.Robot;
        public void Work() => Console.WriteLine("Robot assembling parts.");     
    }

    //SRP? Yes, only generation
    //OCP? Yes, no iteration over types
    //Liskov? No, code "asks" for type, so logic can depend on it...
    public class SOLIDReportGenerator
    {
        public void GenerateReport(List<IWorker> employees)
        {
            foreach (var employee in employees)
            {
                employee.Work();
            }            
        }
    }


    //DIP? No, Generation depends on low-level write logic
    public class SOLIDReportSaver
    {
        ILogger logger;
        public SOLIDReportSaver(ILogger logger)
        {
            this.logger = logger;
        }

        public void Save()
        {
            logger.LogDebug("Generating report...");
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void LogDebug(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[DEBUG] {message}");
            Console.ResetColor();
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string msg)
        {
            throw new NotImplementedException();
        }

        public string GetError()
        {
            throw new NotImplementedException();
        }
    }
}
