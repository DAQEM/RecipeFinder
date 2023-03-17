using BLL.Data.Cook.Follower;
using BLL.Entities.Cook;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class FollowerRepository : IFollowerRepository
{
    public List<Cook> GetForCookId(Guid cookId)
    {
        const string query = "SELECT id, username, fullname, image_url " +
                             "FROM Cook " +
                             "WHERE id IN " +
                             "(SELECT followed_id " +
                             "FROM Follower " +
                             "WHERE follower_id = @cookId)";
        
        MySqlParameter[] parameters =
        {
            new("@cookId", cookId)
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Cook(
                id: reader.GetGuid("id"),
                username: reader.GetString("username"),
                fullname: reader.GetString("fullname"),
                imageUrl: reader.GetString("image_url")
            ));
    }

    public void Add(Guid cookId, Guid followingId)
    {
        const string query = "INSERT INTO Follower (id, follower_id, followed_id) " +
                             "VALUES (@id, @cookId, @followingId);";
        
        MySqlParameter[] parameters =
        {
            new("@id", Guid.NewGuid()),
            new("@cookId", cookId),
            new("@followingId", followingId)
        };
        
        QueryHelper.NonQuery(query, parameters);
    }

    public void Delete(Guid cookId, Guid followingId)
    {
        const string query = "DELETE FROM Follower " +
                             "WHERE follower_id = @cookId AND followed_id = @followingId;";
        
        MySqlParameter[] parameters =
        {
            new("@cookId", cookId),
            new("@followingId", followingId)
        };
        
        QueryHelper.NonQuery(query, parameters);
    }
}