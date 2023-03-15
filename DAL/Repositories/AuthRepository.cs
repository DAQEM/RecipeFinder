using BLL.Data.Auth;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class AuthRepository : IAuthRepository
{
    public string? Login(string username, string hashedPassword)
    {
        const string query = "SELECT username FROM Cook WHERE id = (SELECT cook_id FROM Credential WHERE cook_id = (SELECT id FROM Cook WHERE username = @username) AND password = @hashedPassword);";
        MySqlParameter[] parameters =
        {
            new("@username", username),
            new("@hashedPassword", hashedPassword)
        };
        return QueryHelper.QuerySingle(query, parameters, reader => reader.GetString("username"));
    }

    public bool PasswordCorrect(string username, string hashedPassword)
    {
        const string query = "SELECT COUNT(*) " +
                       "FROM Credential " +
                       "WHERE cook_id = (SELECT id FROM Cook WHERE username = @username) " +
                       "AND password = @hashedPassword;";
        
        MySqlParameter[] parameters = {
            new("@username", username), 
            new("@hashedPassword", hashedPassword)
        };
        
        return QueryHelper.QuerySingle(query, parameters, reader => reader.GetInt32("COUNT(*)")) == 1;
    }

    public bool IsEmailTaken(string email)
    {
        return IsTaken("Credential", "email", email);
    }

    public bool IsUsernameTaken(string username)
    {
        return IsTaken("Cook", "username", username);
    }

    private static bool IsTaken(string table, string column, string toCheck)
    {
        string query = $"SELECT COUNT(*) FROM {table} WHERE {column} = @toCheck;";
        MySqlParameter[] parameters =
        {
            new("@toCheck", toCheck)
        };
        return QueryHelper.QuerySingle(query, parameters, reader => reader.GetInt32("COUNT(*)")) > 0;
    }
}