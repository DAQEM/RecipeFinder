using BLL.Data.Recipe.Ingredient;
using BLL.Entities.Recipe.Ingredient;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class IngredientRepository : IIngredientRepository
{
    public List<Ingredient> GetByRecipeId(Guid id)
    {
        const string query = "SELECT name, description, quantity, unit FROM Ingredient WHERE recipe_id = @RecipeId";
        
        MySqlParameter[] parameters =
        {
            new("@RecipeId", id)
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new Ingredient(
                name: reader.GetString("name"),
                description: reader.GetString("description"),
                quantity: reader.GetDecimal("quantity"),
                unit: (Unit)reader.GetInt32("unit")
            ));
    }
}