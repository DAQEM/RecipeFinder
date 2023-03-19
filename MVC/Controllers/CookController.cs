using BLL.Data.Cook;
using BLL.Entities.Cook;
using BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using MVC.Handlers;
using MVC.Models.Cook;

namespace MVC.Controllers;

[Route("Cook")]
public class CookController : BaseController<CookController>
{
    private readonly ICookService _cookService;
    
    public CookController(ICookService cookService)
    {
        _cookService = cookService;
    }
    
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        string searchString = HttpContext.Request.Query["search"].ToString();

        List<Cook> cooks = _cookService.GetBySearch(searchString);
        Cook? viewer = GetViewer(_cookService);
        
        return View(new CookListModel { Cooks = cooks, Viewer = viewer });
    }
    
    [HttpGet]
    [Route("{username}")]
    public IActionResult Cook(string username)
    {
        try
        {
            Cook cook = _cookService.GetByUsernameWithRecipes(username);
            Cook? viewer = GetViewer(_cookService);
            CookModel cookModel = new(){ Cook = cook, Viewer = viewer };
            return View("CookRecipes", cookModel);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpGet]
    [Route("{username}/Reviews")]
    public IActionResult CookReviews(string username)
    {
        try
        {
            Cook cook = _cookService.GetByUsernameWithCookReviews(username);
            Cook? viewer = GetViewer(_cookService);
            return View("CookReviews", new CookModel { Cook = cook, Viewer = viewer});
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpGet]
    [Route("{username}/Edit")]
    public IActionResult EditCook(string username)
    {
        try
        {
            if (!Auth.IsUser(username)) return Unauthorized();
            Cook cook = _cookService.GetByUsernameWithCredentials(username);
            return View(EditCookModel.FromCook(cook));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    [Route("{username}/Edit/")]
    public IActionResult EditCook(string username, EditCookModel model)
    {
        if (Auth.IsUser(username)) return Unauthorized();
        
        List<string> errors = EditCookHandler.GetErrors(model);
        if (errors.Any())
        {
            ViewBag.ErrorMessages = errors;
        }
        else
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ViewBag.SuccessMessage = "Successfully saved changes.";

                    Cook cook = _cookService.GetByUsernameWithCredentials(username)!;

                    _cookService.UpdateWithCredentials(new Cook(
                        id: cook.Id,
                        username: cook.Username,
                        fullname: model.Fullname,
                        imageUrl: model.ImageUrl,
                        credential: new Credential(
                            email: model.Email,
                            hashedPassword: cook.Credential.HashedPassword,
                            cookId: cook.Id)));
                }
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        return View(model);
    }

    [HttpPost]
    [Route("{username}/Delete")]
    public IActionResult Delete(string username)
    {
        if (!Auth.IsUser(username)) return Unauthorized();
        
        _cookService.Delete(username);
        Auth.Logout();
        
        return Redirect.Home;
        
    }
}