using BLL.Data.Cook.Credential;
using BLL.Entities.Cook;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class CredentialRepository : ICredentialRepository
{
    public void Add(string email, string hashedPassword, Guid cookId)
    {
        const string query =
            "INSERT INTO Credential (id, email, password, cook_id)" +
            " VALUES (@id, @email, @password, @cook_id);";
        
        MySqlParameter[] parameters =
        {
            new("@id", Guid.NewGuid()),
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

    public Credential? GetByCookId(Guid cookId)
    {
        const string query = "SELECT email, password, updated_at, cook_id " +
                             "FROM Credential " +
                             "WHERE cook_id = @cook_id;";
        
        MySqlParameter[] parameters = 
        {
            new("@cook_id", cookId)
        };
        
        return QueryHelper.QuerySingle(query, parameters,
            reader => new Credential(
                email: reader.GetString("email"),
                hashedPassword: reader.GetString("password"),
                updatedAt: reader.GetDateTime("updated_at"),
                cookId: reader.GetGuid("cook_id")
            ));
    }
}