namespace Core.Exceptions;

public class InvalidOdometerException: Exception
{
    public InvalidOdometerException()
    {
    }

    public InvalidOdometerException(string message = "")
        : base(message)
    {
    }

    public InvalidOdometerException(string message, Exception inner)
        : base(message, inner)
    {
    }
}