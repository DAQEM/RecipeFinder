namespace BLL.Entities.Recipe;

public class PreparationStep
{
    private int _order;
    private string _description;
    
    public PreparationStep(int order, string description)
    {
        _order = order;
        _description = description;
    }
    
    public int Order => _order;
    
    public string Description => _description;
    
    public void SetOrder(int order)
    {
        _order = order;
    }
    
    public void SetDescription(string description)
    {
        _description = description;
    }
}