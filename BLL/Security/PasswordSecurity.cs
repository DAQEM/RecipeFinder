using System.Security.Cryptography;
using System.Text;

namespace BLL.Security;

public static class PasswordSecurity
{
    public static string HashPassword(string password)
    {
        byte[] message = Encoding.UTF8.GetBytes(password);
        byte[] hashValue = SHA512.HashData(message);
        const string seed = "";
        return hashValue.Aggregate(seed, (current, x) => current + $"{x:x2}");
    }
}