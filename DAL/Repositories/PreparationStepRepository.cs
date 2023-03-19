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
}