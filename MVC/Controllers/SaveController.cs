using BLL.Data.Cook;
using BLL.Data.Recipe;
using BLL.Data.Recipe.Saver;
using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class SaveController : BaseController<SaveController>
{
    private readonly ISaverService _saverService;
    private readonly ICookService _cookService;
    private readonly IRecipeService _recipeService;
    
    public SaveController(ISaverService saverService, ICookService cookService, IRecipeService recipeService)
    {
        _saverService = saverService;
        _cookService = cookService;
        _recipeService = recipeService;
    }
    
    [HttpPost]
    [Route("Save/{recipeId}")]
    public IActionResult Save(Guid recipeId)
    {
        if (!Auth.IsLoggedIn()) return Unauthorized();
        try
        {
            Cook cook = _cookService.GetByUsername(Auth.GetSessionUsername()!);
            Recipe recipe = _recipeService.GetById(recipeId);
            _saverService.Add(recipe, cook);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        return Ok();
    }
    
    [HttpPost]
    [Route("Unsave/{recipeId}")]
    public IActionResult Unsave(Guid recipeId)
    {
        if (!Auth.IsLoggedIn()) return Unauthorized();
        try
        {
            Cook cook = _cookService.GetByUsername(Auth.GetSessionUsername()!);
            Recipe recipe = _recipeService.GetById(recipeId);
            _saverService.Remove(recipe, cook);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        return Ok();
    }
}