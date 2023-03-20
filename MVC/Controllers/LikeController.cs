using BLL.Data.Cook;
using BLL.Data.Recipe;
using BLL.Data.Recipe.Liker;
using BLL.Entities.Cook;
using BLL.Entities.Recipe;
using BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class LikeController : BaseController<LikeController>
{
    private readonly ILikerService _likerService;
    private readonly ICookService _cookService;
    private readonly IRecipeService _recipeService;
    
    public LikeController(ILikerService likerService, ICookService cookService, IRecipeService recipeService)
    {
        _likerService = likerService;
        _cookService = cookService;
        _recipeService = recipeService;
    }
    
    [HttpPost]
    [Route("Like/{recipeId}")]
    public IActionResult Like(Guid recipeId)
    {
        if (!Auth.IsLoggedIn()) return Unauthorized();
        try
        {
            Cook cook = _cookService.GetByUsername(Auth.GetSessionUsername()!);
            Recipe recipe = _recipeService.GetById(recipeId);
            _likerService.Add(recipe, cook);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        return Ok();
    }
    
    [HttpPost]
    [Route("Unlike/{recipeId}")]
    public IActionResult Unlike(Guid recipeId)
    {
        if (!Auth.IsLoggedIn()) return Unauthorized();
        try
        {
            Cook cook = _cookService.GetByUsername(Auth.GetSessionUsername()!);
            Recipe recipe = _recipeService.GetById(recipeId);
            _likerService.Remove(recipe, cook);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        return Ok();
    }
}