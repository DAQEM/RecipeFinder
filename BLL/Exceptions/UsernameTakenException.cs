namespace BLL.Exceptions;

public class UsernameTakenException : Exception
{
    public UsernameTakenException() : base("Requested username is already taken.")
    {
    }
}