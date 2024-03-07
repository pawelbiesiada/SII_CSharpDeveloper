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
        Read,
        Write,
        Delete,
        Create
    }
}
