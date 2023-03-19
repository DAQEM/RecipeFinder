namespace BLL.Entities.Recipe;

public class PreparationStep
{
    private readonly int _order;
    private readonly string _description;
    
    public PreparationStep(int order = 0, string description = "")
    {
        _order = order;
        _description = description;
    }
    
    public int Order => _order;
    public string Description => _description;
}