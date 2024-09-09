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
        Read = 0,
        Write = 1,
        Delete = 2,
        Create = 4
    }
}
