namespace BLL.Exceptions;

public class UsernameNotFoundException : Exception
{
    public UsernameNotFoundException() : base("Requested username was not found.")
    {
    }
}