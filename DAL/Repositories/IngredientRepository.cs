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

    public void DeleteByRecipeId(Guid recipeId)
    {
        const string query = "DELETE FROM Ingredient WHERE recipe_id = @RecipeId";
        
        MySqlParameter[] parameters =
        {
            new("@RecipeId", recipeId)
        };
        
        QueryHelper.NonQuery(query, parameters);
    }

    public void Add(Guid recipeId, Ingredient ingredient)
    {
        const string query = "INSERT INTO Ingredient (id, recipe_id, name, description, quantity, unit) " +
                             "VALUES (@Id, @RecipeId, @Name, @Description, @Quantity, @Unit);";
        
        MySqlParameter[] parameters =
        {
            new("@Id", Guid.NewGuid()),
            new("@RecipeId", recipeId),
            new("@Name", ingredient.Name),
            new("@Description", ingredient.Description),
            new("@Quantity", ingredient.Quantity),
            new("@Unit", (int)ingredient.Unit)
        };
            
        QueryHelper.NonQuery(query, parameters);
    }
}