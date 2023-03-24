using BLL.Data.Cook;
using BLL.Data.Recipe;
using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using BLL.Entities.Recipe.Ingredient;
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

        CreateRecipeModel model = CreateRecipeModel.FromRecipe(recipe, viewer);
        
        return View(model);
    }
    
    [HttpPost]
    [Route("{recipeId}/Edit")]
    public IActionResult EditRecipe(Guid recipeId, CreateRecipeModel model)
    {
        Recipe recipe = new(
            id: recipeId,
            name: model.Name,
            imageUrl: model.ImageUrl,
            description: model.Description,
            preparationTime: model.PreparationTime,
            category: model.Category,
            ingredients: model.Ingredients.Select(ingredient => new Ingredient(
                name: ingredient.Name,
                description: "",
                quantity: ingredient.Quantity,
                unit: ingredient.Unit ?? Unit.Gram
            )).ToArray(),
            preparationSteps: model.PreparationSteps.Select(step => new PreparationStep(
                order: step.Order,
                description: step.Description
            )).ToArray());
        
        _recipeService.UpdateWithIngredientsAndPreparationSteps(recipeId, recipe);
        
        return View("EditRecipe", model);
    }
    
    [HttpGet]
    [Route("Create")]
    public IActionResult CreateRecipe()
    {
        if (!Auth.IsLoggedIn()) return Redirect.Login;
        
        Cook? viewer = GetViewer(_cookService);
        return View(CreateRecipeModel.FromRecipe(new Recipe(), viewer));
    }
    
    [HttpPost]
    [Route("Create")]
    public IActionResult CreateRecipe(CreateRecipeModel model)
    {
        if (!Auth.IsLoggedIn()) return Unauthorized();
        
        Cook? viewer = GetViewer(_cookService);
        if (viewer == null) return Unauthorized();
        
        Recipe recipe = new(
            id: Guid.NewGuid(),
            name: model.Name,
            imageUrl: model.ImageUrl,
            description: model.Description,
            preparationTime: model.PreparationTime,
            category: model.Category,
            cookId: viewer.Id,
            ingredients: model.Ingredients.Select(ingredient => new Ingredient(
                name: ingredient.Name,
                description: "",
                quantity: ingredient.Quantity,
                unit: ingredient.Unit ?? Unit.Gram
            )).ToArray(),
            preparationSteps: model.PreparationSteps.Select(step => new PreparationStep(
                order: step.Order,
                description: step.Description
            )).ToArray());
        
        _recipeService.CreateWithIngredientsAndPreparationSteps(recipe, viewer.Id);
        
        return Redirect.Home;
    }
}