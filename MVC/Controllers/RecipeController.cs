using BLL.Data.Cook;
using BLL.Data.Recipe;
using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Cook;
using MVC.Models.Recipe;

namespace MVC.Controllers;

[Route("Recipe")]
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
    [Route("")]
    public IActionResult Index()
    {
        string searchString = HttpContext.Request.Query["search"].ToString();

        List<Recipe> recipes = _recipeService.GetBySearch(searchString);
        Cook? viewer = GetViewer(_cookService);
        
        return View(new RecipeListModel() { Recipes = recipes, Viewer = viewer });
    }
    
    [HttpGet]
    [Route("{id}")]
    public IActionResult Recipe(Guid id)
    {
        try
        {
            Cook cook = _cookService.GetWithRecipe(id);
            Cook? viewer = GetViewer(_cookService);
            return View( new CookModel { Cook = cook, Viewer = viewer} );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        
    }

    [HttpGet]
    [Route("{recipeId}/Edit")]
    public IActionResult EditRecipe(Guid recipeId)
    {
        if (!Auth.IsLoggedIn()) return Unauthorized();
        
        Recipe recipe = _recipeService.GetByIdDetailed(recipeId);
        Cook? viewer = GetViewer(_cookService);
        
        if (viewer != null && recipe.CookId != viewer.Id) return Unauthorized();

        EditRecipeModel model = EditRecipeModel.FromRecipe(recipe, viewer);
        
        return View(model);
    }
    
    [HttpPost]
    [Route("{recipeId}/Edit")]
    public IActionResult EditRecipe(Guid recipeId, EditRecipeModel model)
    {
        Console.WriteLine(model.Name);
        return View("EditRecipe", model);
    }
}