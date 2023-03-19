using BLL.Entities.Recipe;

namespace BLL.Data.Recipe.Preparation;

public interface IPreparationStepRepository
{
    List<PreparationStep> GetByRecipeId(Guid id);
}