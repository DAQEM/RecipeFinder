using BLL.Data.Cook;
using BLL.Data.Recipe;
using BLL.Entities.Cook;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Cook;

namespace MVC.Controllers;

public class RecipeController : BaseController<RecipeController>
{
    private readonly ICookService _cookService;
    private readonly IRecipeService _recipeService;
    
    public RecipeController(ICookService cookService, IRecipeService recipeService)
    {
        _cookService = cookService;
        _recipeService = recipeService;
    }
    
    [HttpGet]
    [Route("Recipe/{id}")]
    public IActionResult Recipe(Guid id)
    {
        Cook? cook = _cookService.GetByRecipeIdWithRecipe(id);
        return cook == null || cook.Recipes.Length == 0 ? Redirect.NotFound : View( new CookModel { Cook = cook } );
    }
}