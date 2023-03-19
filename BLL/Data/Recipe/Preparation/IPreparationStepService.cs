using BLL.Entities.Recipe;

namespace BLL.Data.Recipe.Preparation;

public interface IPreparationStepService
{
    List<PreparationStep> GetByRecipeId(Guid id);
}