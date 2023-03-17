using BLL.Data.Cook;
using BLL.Entities.Cook;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class CookRepository : ICookRepository
{
    public List<Cook> GetAll()
    {
        const string query = "SELECT id, username, fullname, image_url, created_at " +
                             "FROM Cook";

        return QueryHelper.QueryMultiple(query, null,
            reader => new Cook(
                id: reader.GetGuid("id"),
                username: reader.GetString("username"),
                fullname: reader.GetString("fullname"),
                imageUrl: reader.GetString("image_url"),
                createdAt: reader.GetDateTime("created_at")
            ));
    }

    public Cook? GetById(Guid id)
    {
        const string query = "SELECT id, username, fullname, image_url, created_at " +
                             "FROM Cook " + 
                             "WHERE id = @id;";
        
        MySqlParameter[] parameters =
        {
            new("@id", id)
        };
        
        return QueryHelper.QuerySingle(query, parameters,
            reader => new Cook(
                id: reader.GetGuid("id"),
                username: reader.GetString("username"),
                fullname: reader.GetString("fullname"),
                imageUrl: reader.GetString("image_url"),
                createdAt: reader.GetDateTime("created_at")
            ));
    }

    public Cook? GetByUserName(string username)
    {
        const string query = "SELECT id, username, fullname, image_url, created_at " +
                             "FROM Cook " +
                             "WHERE username = @username;";
        
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };
        
        return QueryHelper.QuerySingle(query, parameters,
            reader => new Cook(
                id: reader.GetGuid("id"),
                username: reader.GetString("username"),
                fullname: reader.GetString("fullname"),
                imageUrl: reader.GetString("image_url"),
                createdAt: reader.GetDateTime("created_at")
            ));
    }

    public void Add(Cook cook)
    {
        const string query =
            "INSERT INTO Cook (id, username, fullname, image_url) " +
            "VALUES (@id, @username, @fullname, @image_url);";
        MySqlParameter[] parameters =
        {
            new("@id", cook.Id),
            new("@username", cook.Username),
            new("@fullname", cook.Fullname),
            new("@image_url", cook.ImageUrl == string.Empty ? "https://i.imgur.com/ShL15rC.png" : cook.ImageUrl)
        };
        QueryHelper.NonQuery(query, parameters);
    }

    public void Update(Cook cook)
    {
        UpdateCook(cook);
    }

    private static void UpdateCook(Cook cook)
    {
        const string cookQuery = "UPDATE Cook " +
                                 "SET username = @username, fullname = @fullname, image_url = @image_url " +
                                 "WHERE id = @id;";

        MySqlParameter[] cookParameters =
        {
            new("@username", cook.Username),
            new("@fullname", cook.Fullname),
            new("@image_url", cook.ImageUrl),
            new("@id", cook.Id)
        };

        QueryHelper.NonQuery(cookQuery, cookParameters);
    }

    public void Delete(string username)
    {
        const string query = "DELETE FROM Cook WHERE username = @username;";
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };
        QueryHelper.NonQuery(query, parameters);
    }
}