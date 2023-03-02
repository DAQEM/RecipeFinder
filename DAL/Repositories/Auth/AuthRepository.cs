using BLL.Data.Auth;
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
        CreateCook(cookId, username, fullName);
        CreateCredential(credentialId, cookId, email, hashedPassword);
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