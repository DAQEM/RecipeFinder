using BLL.Entities.Recipe;

namespace BLL.Data.Recipe.Preparation;

public class PreparationStepService : IPreparationStepService
{
    private readonly IPreparationStepRepository _preparationStepRepository;
    
    public PreparationStepService(IPreparationStepRepository preparationStepRepository)
    {
        _preparationStepRepository = preparationStepRepository;
    }

    public List<PreparationStep> GetByRecipeId(Guid id)
    {
        return _preparationStepRepository.GetByRecipeId(id);
    }

    public void UpdateForRecipeId(Guid recipeId, PreparationStep[] recipePreparationSteps)
    {
        _preparationStepRepository.DeleteByRecipeId(recipeId);
        foreach (PreparationStep preparationStep in recipePreparationSteps)
        {
            _preparationStepRepository.Add(recipeId, preparationStep);
        }
    }

    public void CreateForRecipeId(Guid recipeId, PreparationStep[] recipePreparationSteps)
    {
        foreach (PreparationStep preparationStep in recipePreparationSteps)
        {
            _preparationStepRepository.Add(recipeId, preparationStep);
        }
    }
}