namespace BLL.Data.Recipe.Preparation;

public class PreparationStepService : IPreparationStepService
{
    private readonly IPreparationStepRepository _preparationStepRepository;
    
    public PreparationStepService(IPreparationStepRepository preparationStepRepository)
    {
        _preparationStepRepository = preparationStepRepository;
    }
}