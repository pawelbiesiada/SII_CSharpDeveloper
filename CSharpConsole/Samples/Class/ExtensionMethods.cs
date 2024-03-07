using CSharpConsole.Samples.Class.Inheritance;

namespace CSharpConsole.Samples.Class
{
    public static class ExtensionMethods
    {
        public static void WorkHard(this Bulldozer bulldozer)
        {
            while (!bulldozer.IsServiceCheckNeeded())
            {
                bulldozer.DoSomeWork();
            }
        }
        public static string WorkHard(this Bulldozer bulldozer, int times)
        {
            while (!bulldozer.IsServiceCheckNeeded() && times > 0)
            {
                bulldozer.DoSomeWork();
                times--;
            }

            return "Work completed";
        }


        public static bool IsValidEmailAddress(this string email)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }
    }
}
