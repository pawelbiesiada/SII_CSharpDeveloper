namespace DIProject.Logging
{
    public interface ILogger
    {
        void LogDebug(string msg);
        void LogWarning(string msg);
        void LogError(string msg);
    }
}
