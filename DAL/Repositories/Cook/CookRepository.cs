using BLL.Data.Cook;
using MySql.Data.MySqlClient;

namespace DAL.Repositories.Cook;

public class CookRepository : ICookRepository
{
    public List<BLL.Entities.Cook> GetAll()
    {
        const string query = "SELECT * FROM Cook;";
        return QueryHelper.QueryMultiple(query, null,
            reader => new BLL.Entities.Cook.Builder()
                .WithId(reader.GetGuid("id"))
                .WithUserName(reader.GetString("username"))
                .WithFullName(reader.GetString("fullname"))
                .WithImageUri(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .Build());
    }

    public BLL.Entities.Cook GetById(Guid id)
    {
        const string query = "SELECT * FROM Cook WHERE id = @id;";
        MySqlParameter[] parameters =
        {
            new("@id", id)
        };
        return QueryHelper.QuerySingle(query, parameters,
            reader => new BLL.Entities.Cook.Builder()
                .WithId(reader.GetGuid("id"))
                .WithUserName(reader.GetString("username"))
                .WithFullName(reader.GetString("fullname"))
                .WithImageUri(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .Build());
    }

    public BLL.Entities.Cook GetByUserName(string username)
    {
        const string query = "SELECT * FROM Cook WHERE username = @username;";
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };
        return QueryHelper.QuerySingle(query, parameters,
            reader => new BLL.Entities.Cook.Builder()
                .WithId(reader.GetGuid("id"))
                .WithUserName(reader.GetString("username"))
                .WithFullName(reader.GetString("fullname"))
                .WithImageUri(reader.GetString("image_url"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .Build());
    }

    public void Add(BLL.Entities.Cook cook)
    {
        
    }

    public void Update(BLL.Entities.Cook cook)
    {
        
    }

    public void Delete(BLL.Entities.Cook cook)
    {
        
    }
}