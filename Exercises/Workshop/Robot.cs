using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Workshop
{
    public class Robot
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                if (value is null || value == string.Empty)
                    throw new ArgumentException();

                _name = value; 
            }
        }

        public string Greet
        {
            get {
                return "Hi I am " + Name; 
            }
        }

        public ushort Age { get; set; }
        public bool IsOn { get; set; }

        public Robot() : this("John", 18)
        { }

        public Robot(string name, ushort age)
        {
            Name = name;
            Age = age;
            IsOn = true;
        }

        public string GetGreet()
        {
            return "Hi I am " + Name;
        }

        public void SayHi()
        {
            if (IsOn == true)
                Console.WriteLine("Say Hi" + Name);
        }
    }

    public class TestRobot
    {
        public static void main(string[] args)
        {

            Robot robot = new Robot("Michal", 12);
            robot.SayHi();

            robot.Name = "Alex";
            Console.WriteLine(robot.Greet);
            Console.WriteLine(robot.GetGreet());

            robot = new Robot();
        }
    }
}

