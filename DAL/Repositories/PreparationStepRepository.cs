using BLL.Data.Recipe.Preparation;
using BLL.Entities.Recipe;
using DAL.Helpers;
using MySql.Data.MySqlClient;

namespace DAL.Repositories;

public class PreparationStepRepository : IPreparationStepRepository
{
    public List<PreparationStep> GetByRecipeId(Guid id)
    {
        const string query = "SELECT step_order, description FROM PreparationStep WHERE recipe_id = @RecipeId";

        MySqlParameter[] parameters =
        {
            new("@RecipeId", id)
        };
        
        return QueryHelper.QueryMultiple(query, parameters,
            reader => new PreparationStep(
                order: reader.GetInt32("step_order"),
                description: reader.GetString("description")
            ));
    }

    public void DeleteByRecipeId(Guid recipeId)
    {
        const string query = "DELETE FROM PreparationStep WHERE recipe_id = @RecipeId";

        MySqlParameter[] parameters =
        {
            new("@RecipeId", recipeId)
        };

        QueryHelper.NonQuery(query, parameters);
    }

    public void Add(Guid recipeId, PreparationStep preparationStep)
    {
        const string query = "INSERT INTO PreparationStep (id, recipe_id, step_order, description) " +
                             "VALUES (@Id, @RecipeId, @StepOrder, @Description);";

        MySqlParameter[] parameters =
        {
            new("@Id", Guid.NewGuid()),
            new("@RecipeId", recipeId),
            new("@StepOrder", preparationStep.Order),
            new("@Description", preparationStep.Description)
        };

        QueryHelper.NonQuery(query, parameters);
    }
}