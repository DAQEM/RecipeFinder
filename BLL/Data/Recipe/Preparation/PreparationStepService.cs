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
}