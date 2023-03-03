using BLL.Data.Cook;
using BLL.Entities.Cook;
using MySql.Data.MySqlClient;

namespace DAL.Repositories.Cook;

public class CookRepository : ICookRepository
{
    public List<BLL.Entities.Cook.Cook> GetAll()
    {
        const string query = "SELECT Cook.*, Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id;";
        return QueryHelper.QueryMultiple(query, null,
            reader => new BLL.Entities.Cook.Cook.Builder()
                .WithId(reader.GetGuid("id"))
                .WithUserName(reader.GetString("username"))
                .WithFullName(reader.GetString("fullname"))
                .WithImageUri(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithCredential( new Credential(
                    reader.GetString("email"),
                    reader.GetString("password"),
                    reader.GetDateTime("updated_at")))
                .Build());
    }

    public BLL.Entities.Cook.Cook? GetById(Guid id)
    {
        const string query = "SELECT Cook.*, Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id " +
                             "WHERE Cook.id = @id;";
        MySqlParameter[] parameters =
        {
            new("@id", id)
        };
        return QueryHelper.QuerySingle(query, parameters,
            reader => new BLL.Entities.Cook.Cook.Builder()
                .WithId(reader.GetGuid("id"))
                .WithUserName(reader.GetString("username"))
                .WithFullName(reader.GetString("fullname"))
                .WithImageUri(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithCredential( new Credential(
                    reader.GetString("email"),
                    reader.GetString("password"),
                    reader.GetDateTime("updated_at")))
                .Build());
    }

    public BLL.Entities.Cook.Cook? GetByUserName(string username)
    {
        const string query = "SELECT Cook.*, Credential.email, Credential.password, Credential.updated_at " +
                             "FROM Cook " +
                             "INNER JOIN Credential ON Cook.id = Credential.cook_id " +
                             "WHERE username = @username;";
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };
        return QueryHelper.QuerySingle(query, parameters,
            reader => new BLL.Entities.Cook.Cook.Builder()
                .WithId(reader.GetGuid("id"))
                .WithUserName(reader.GetString("username"))
                .WithFullName(reader.GetString("fullname"))
                .WithImageUri(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithCredential( new Credential(
                    reader.GetString("email"),
                    reader.GetString("password"),
                    reader.GetDateTime("updated_at")))
                .Build());
    }

    public void Add(BLL.Entities.Cook.Cook cook)
    {
        
    }

    public void Update(BLL.Entities.Cook.Cook cook)
    {
        
    }

    public void Delete(BLL.Entities.Cook.Cook cook)
    {
        
    }
}