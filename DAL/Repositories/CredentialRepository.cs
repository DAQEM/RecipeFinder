using BLL.Data.Cook.Credential;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class CredentialRepository : ICredentialRepository
{
    public void Add(Guid id, string email, string hashedPassword, Guid cookId)
    {
        const string query =
            "INSERT INTO Credential (id, email, password, cook_id)" +
            " VALUES (@id, @email, @password, @cook_id);";
        
        MySqlParameter[] parameters =
        {
            new("@id", id),
            new("@email", email),
            new("@password", hashedPassword),
            new("@cook_id", cookId)
        };
        QueryHelper.NonQuery(query, parameters);
    }

    public void Update(string email, string hashedPassword, Guid cookId)
    {
        const string credentialQuery = "UPDATE Credential " +
                                       "SET email = @email, password = @hashed_password " +
                                       "WHERE cook_id = @cook_id;";

        MySqlParameter[] credentialParameters =
        {
            new("@email", email),
            new("@hashed_password", hashedPassword),
            new("@cook_id", cookId)
        };

        QueryHelper.NonQuery(credentialQuery, credentialParameters);
    }
}