namespace BLL.Exceptions;

public class EmailTakenException : Exception
{
    public EmailTakenException() : base("Requested email address is already taken.")
    {
    }
}