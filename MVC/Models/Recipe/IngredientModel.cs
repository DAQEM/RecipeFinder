using BLL.Entities.Recipe.Ingredient;

namespace MVC.Models.Recipe;

public class IngredientModel
{
    public string Name { get; set; } = "";
    public decimal Quantity { get; set; } = 0;
    public Unit? Unit { get; set; }
}