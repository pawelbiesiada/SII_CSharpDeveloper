using System;

namespace CSharpConsole.Samples.Types
{
    public enum OperationType
    {
        Add = 0,
        Subtract = 1,
        Divide = 2,
        Multiply = 3
    }
    [Flags]
    public enum FilePrivileges
    {
        Read=1,
        Write=2,
        Delete=4,
        Create=8
    }
}
