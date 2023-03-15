using BLL.Data.Recipe;
using BLL.Entities.Recipe;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class RecipeRepository : IRecipeRepository
{
    public List<Recipe> GetRecipesByUsername(string username)
    {
        const string query = "SELECT Recipe.id, name, Recipe.image_url, description, preparation_time, category, Recipe.created_at, updated_at, cook_id " +
                             "FROM Recipe " +
                             "INNER JOIN Cook ON Recipe.cook_id = Cook.id " +
                             "WHERE Cook.username = @username;";
        MySqlParameter[] parameters =
        {
            new("@username", username)
        };
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Recipe.Builder()
                .WithId(reader.GetGuid("id"))
                .WithName(reader.GetString("name"))
                .WithImageUrl(reader.GetString("image_url"))
                .WithDescription(reader.GetString("description"))
                .WithPreparationTime(reader.GetTimeSpan("preparation_time"))
                .WithCategory((Category)reader.GetInt32("category"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithUpdatedAt(reader.GetDateTime("updated_at"))
                .WithCookId(reader.GetGuid("cook_id"))
                .WithIngredients(null)
                .WithPreparationSteps(null)
                .WithReviews(null)
                .WithLikers(null)
                .Build());
    }

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
            reader => new Recipe.Builder()
                .WithId(reader.GetGuid("id"))
                .WithName(reader.GetString("name"))
                .WithImageUrl(reader.GetString("image_url"))
                .WithDescription(reader.GetString("description"))
                .WithPreparationTime(reader.GetTimeSpan("preparation_time"))
                .WithCategory((Category)reader.GetInt32("category"))
                .WithCreatedAt(reader.GetDateTime("created_at"))
                .WithUpdatedAt(reader.GetDateTime("updated_at"))
                .WithCookId(reader.GetGuid("cook_id"))
                .WithIngredients(null)
                .WithPreparationSteps(null)
                .Build());
    }
}