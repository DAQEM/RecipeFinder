using BLL.Data.Recipe.Saver;
using BLL.Entities.Cook;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class SaverRepository : ISaverRepository
{
    public List<Cook> GetForRecipeId(Guid recipeId)
    {
        const string query = "SELECT id, username, fullname, image_url " +
                             "FROM Cook " +
                             "WHERE id IN " +
                             "(SELECT cook_id " +
                             "FROM Save " +
                             "WHERE recipe_id = @recipeId)";
        
        MySqlParameter[] parameters =
        {
            new("@recipeId", recipeId)
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Cook(
                id: reader.GetGuid("id"),
                username: reader.GetString("username"),
                fullname: reader.GetString("fullname"),
                imageUrl: reader.GetString("image_url")
            ));
    }

    public void Add(Guid recipeId, Guid cookId)
    {
        const string query = "INSERT INTO Save (id, recipe_id, cook_id) " +
                             "VALUES (@id, @recipeId, @cookId);";
        
        MySqlParameter[] parameters =
        {
            new("@id", Guid.NewGuid()),
            new("@recipeId", recipeId),
            new("@cookId", cookId)
        };
        
        QueryHelper.NonQuery(query, parameters);
    }

    public void Remove(Guid recipeId, Guid cookId)
    {
        const string query = "DELETE FROM Save " +
                             "WHERE recipe_id = @recipeId AND cook_id = @cookId;";
        
        MySqlParameter[] parameters =
        {
            new("@recipeId", recipeId),
            new("@cookId", cookId)
        };
        
        QueryHelper.NonQuery(query, parameters);
    }
}