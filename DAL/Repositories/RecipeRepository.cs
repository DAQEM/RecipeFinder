using BLL.Data.Recipe;
using BLL.Entities.Recipe;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class RecipeRepository : IRecipeRepository
{
    public Recipe? GetById(Guid id)
    {
        const string query = "SELECT id, name, image_url, description, preparation_time, category, created_at, updated_at, cook_id " +
                       "FROM Recipe " +
                       "WHERE Recipe.id = @id;";
        
        MySqlParameter[] parameters = 
        {
            new("@id", id)
        };
        
        return QueryHelper.QuerySingle(query, parameters, 
            reader => new Recipe( 
                id: reader.GetGuid("id"),
                name: reader.GetString("name"),
                imageUrl: reader.GetString("image_url"),
                description: reader.GetString("description"),
                preparationTime: reader.GetTimeSpan("preparation_time"),
                category: (Category)reader.GetInt32("category"),
                createdAt: reader.GetDateTime("created_at"),
                updatedAt: reader.GetDateTime("updated_at"),
                cookId: reader.GetGuid("cook_id")
            ));
    }

    public List<Recipe> GetByCookId(Guid cookId)
    {
        const string query = "SELECT id, name, Recipe.image_url, description, preparation_time, category, created_at, updated_at, cook_id " +
                             "FROM Recipe " +
                             "WHERE cook_id = @cook_id;";
        MySqlParameter[] parameters =
        {
            new("@cook_id", cookId)
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Recipe(
                id: reader.GetGuid("id"),
                name: reader.GetString("name"),
                imageUrl: reader.GetString("image_url"),
                description: reader.GetString("description"),
                preparationTime: reader.GetTimeSpan("preparation_time"),
                category: (Category)reader.GetInt32("category"),
                createdAt: reader.GetDateTime("created_at"),
                updatedAt: reader.GetDateTime("updated_at"),
                cookId: reader.GetGuid("cook_id")
            ));
    }

    public List<Recipe> GetBySearch(string searchString)
    {
        const string query = "SELECT id, name, image_url, description, preparation_time, category, created_at, updated_at, cook_id " +
                             "FROM Recipe " +
                             "WHERE name LIKE @search_string;";
        MySqlParameter[] parameters =
        {
            new("@search_string", $"%{searchString}%")
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Recipe(
                id: reader.GetGuid("id"),
                name: reader.GetString("name"),
                imageUrl: reader.GetString("image_url"),
                description: reader.GetString("description"),
                preparationTime: reader.GetTimeSpan("preparation_time"),
                category: (Category)reader.GetInt32("category"),
                createdAt: reader.GetDateTime("created_at"),
                updatedAt: reader.GetDateTime("updated_at"),
                cookId: reader.GetGuid("cook_id")
            ));
    }
}