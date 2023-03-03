using BLL.Data.Auth;
using BLL.Exceptions;
using MySql.Data.MySqlClient;

namespace DAL.Repositories.Auth;

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

    public void Register(Guid cookId, Guid credentialId, string username, string fullName, string email, string hashedPassword)
    {
        if (UsernameTaken(username)) throw new UsernameTakenException();
        if (EmailTaken(email)) throw new EmailTakenException();

        CreateCook(cookId, username, fullName);
        CreateCredential(credentialId, cookId, email, hashedPassword);
    }

    private bool EmailTaken(string email)
    {
        return CheckTaken("Credential", "email", email);
    }

    private bool UsernameTaken(string username)
    {
        return CheckTaken("Cook", "username", username);
    }

    private static bool CheckTaken(string table, string column, string toCheck)
    {
        string query = $"SELECT COUNT(*) FROM {table} WHERE {column} = @toCheck;";
        MySqlParameter[] parameters =
        {
            new("@toCheck", toCheck)
        };
        return QueryHelper.QuerySingle(query, parameters, reader => reader.GetInt32("COUNT(*)")) > 0;
    }
    
    private static void CreateCook(Guid id, string username, string fullName)
    {
        const string query =
            "INSERT INTO Cook (id, username, fullname, image_url) VALUES (@id, @username, @fullname, @image_url);";
        MySqlParameter[] parameters =
        {
            new("@id", id),
            new("@username", username),
            new("@fullname", fullName),
            new("@image_url", "https://i.imgur.com/ShL15rC.png")
        };
        QueryHelper.NonQuery(query, parameters);
    }
    
    private static void CreateCredential(Guid id, Guid cookId, string email, string password)
    {
        const string query =
            "INSERT INTO Credential (id, email, password, cook_id) VALUES (@id, @email, @password, @cook_id);";
        MySqlParameter[] parameters =
        {
            new("@id", id),
            new("@email", email),
            new("@password", password),
            new("@cook_id", cookId)
        };
        QueryHelper.NonQuery(query, parameters);
    }
}