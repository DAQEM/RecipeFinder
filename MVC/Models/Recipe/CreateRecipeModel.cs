using BLL.Entities.Recipe;

namespace MVC.Models.Recipe;

public class CreateRecipeModel
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public string Description { get; set; } = "";
    public TimeSpan PreparationTime { get; set; } = TimeSpan.Zero;
    public Category Category { get; set; } = Category.None;

    public List<IngredientModel> Ingredients { get; set; } = new();
    public List<PreparationStepModel> PreparationSteps { get; set; } = new();
    
    public BLL.Entities.Cook.Cook? Viewer { get; set; }
    
    public static CreateRecipeModel FromRecipe(BLL.Entities.Recipe.Recipe recipe, BLL.Entities.Cook.Cook? viewer)
    {
        return new CreateRecipeModel
        {
            Id = recipe.Id,
            Name = recipe.Name,
            ImageUrl = recipe.ImageUrl,
            Description = recipe.Description,
            PreparationTime = recipe.PreparationTime,
            Category = recipe.Category,
            Ingredients = recipe.Ingredients.Select(ingredient => new IngredientModel
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
                Unit = ingredient.Unit
            }).ToList(),
            PreparationSteps = recipe.PreparationSteps.Select(step => new PreparationStepModel
            {
                Order = step.Order,
                Description = step.Description
            }).ToList(),
            Viewer = viewer
        };
    }
}