using System.ComponentModel;

namespace Dramankadeh.Core.Exceptions;

public class FrameworkException : Exception
{
    public FrameworkException([Localizable(true)] string message) : base(message)
    {
    }

    public FrameworkException([Localizable(true)] string message, Exception innerException) : base(message,
        innerException)
    {
    }
}