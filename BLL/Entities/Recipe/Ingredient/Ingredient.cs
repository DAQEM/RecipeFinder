namespace BLL.Entities.Recipe.Ingredient;

public class Ingredient
{
    private string _name;
    private string _description;
    private decimal _quantity;
    private Unit _unit;
    
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
    
    public void SetName(string name)
    {
        _name = name;
    }
    
    public void SetDescription(string description)
    {
        _description = description;
    }
    
    public void SetQuantity(decimal quantity)
    {
        _quantity = quantity;
    }
    
    public void SetUnit(Unit unit)
    {
        _unit = unit;
    }
}