using BLL.Data.Recipe;
using BLL.Entities.Recipe;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class RecipeRepository : IRecipeRepository
{
    public List<Recipe> GetRecipesByUsername(string username)
    {
        const string query = "SELECT Recipe.*" +
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
                .Build());
    }
}