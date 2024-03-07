namespace DIProject.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogDebug(string msg)
        {
            Console.WriteLine($"DEBUG - {msg}");
        }

        public void LogWarning(string msg)
        {
            Console.WriteLine($"WARNING - {msg}");
        }

        public void LogError(string msg)
        {
            Console.WriteLine($"ERROR - {msg}");
        }
    }
}
