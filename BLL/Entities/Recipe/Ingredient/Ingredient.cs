namespace BLL.Entities.Recipe.Ingredient;

public class Ingredient
{
    private readonly string _name;
    private readonly string _description;
    private readonly decimal _quantity;
    private readonly Unit _unit;
    
    public Ingredient(string name, string description, decimal quantity, Unit unit)
    {
        _name = name;
        _description = description;
        _quantity = quantity;
        _unit = unit;
    }
    
    public string Name => _name;
    public string Description => _description;
    public decimal Quantity => _quantity;
    public Unit Unit => _unit;
}