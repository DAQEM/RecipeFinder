using BLL.Data.Cook;
using BLL.Entities.Cook;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MVC.Handlers;
using MVC.Models.Auth;
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
        List<Cook> cooks = _cookService.GetAll();
        StringValues searchValues = HttpContext.Request.Query["search"];
        if (searchValues.Any())
        {
            //TODO: Move filter to service
            string search = searchValues.ToString();
            cooks = cooks
                .Where(c => c.Username.Contains(search.ToLower(), StringComparison.OrdinalIgnoreCase) 
                            || c.Fullname.Contains(search.ToLower(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        } 
        return View(new CookListModel { Cooks = cooks });
    }
    
    [HttpGet]
    [Route("{username}")]
    public IActionResult Cook(string username)
    {
        ViewBag.IsOwner = Auth.IsUser(username);
        return View("CookRecipes", new CookModel { Cook = _cookService.GetByUsernameWithRecipes(username)!});
    }
    
    [HttpGet]
    [Route("{username}/Reviews")]
    public IActionResult CookReviews(string username)
    {
        ViewBag.IsOwner = Auth.IsUser(username);
        return View("CookReviews", new CookModel { Cook = _cookService.GetByUsernameWithCookReviews(username)!});
    }
    
    [HttpGet]
    [Route("{username}/Edit")]
    public IActionResult EditCook(string username)
    {
        return Auth.IsUser(username)
            ? View(EditCookModel.FromCook(_cookService.GetByUsername(username)!))
            : Auth.RedirectToNoPermission();
    }
    
    [HttpPost]
    [Route("{username}/Edit/")]
    public IActionResult EditCook(string username, EditCookModel model)
    {
        List<string> errors = EditCookHandler.GetErrors(model);
        if (errors.Any())
        {
            ViewBag.ErrorMessages = errors;
        }
        else
        {
            ViewBag.SuccessMessage = "Successfully saved changes.";
            Cook cook = _cookService.GetByUsername(username)!;
            _cookService.UpdateWithCredentials(new Cook.Builder()
                .WithId(cook.Id)
                .WithUsername(cook.Username)
                .WithFullname(model.Fullname)
                .WithImageUrl(model.ImageUrl)
                .WithCredential(new Credential.Builder()
                    .WithId(cook.Credential.Id)
                    .WithEmail(model.Email)
                    .WithPassword(cook.Credential.HashedPassword)
                    .WithCookId(cook.Id)
                    .Build())
                .Build());
        }

        return Auth.ViewWithPermissionCheck(View(model), username);
    }

    [HttpPost]
    [Route("{username}/Delete")]
    public IActionResult Delete(string username)
    {
        if (Auth.IsUser(username))
        {
            _cookService.Delete(username);
            return Auth.LogoutAndRedirectToHome();
        }
        return Auth.RedirectToNoPermission();
    }
}