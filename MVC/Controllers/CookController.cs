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
public class CookController : Controller
{
    private readonly CookService _cookService;
    private readonly SecurityHandler _securityHandler;
    
    public CookController()
    {
        _cookService = new CookService(new CookRepository());
        _securityHandler = new SecurityHandler(this);
    }
    
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        List<Cook> cooks = _cookService.GetAll();
        StringValues searchValues = HttpContext.Request.Query["search"];
        if (searchValues.Any())
        {
            string search = searchValues.ToString();
            cooks = cooks
                .Where(c => c.Username.ToLower().Contains(search.ToLower()) 
                            || c.Fullname.ToLower().Contains(search.ToLower()))
                .ToList();
        } 
        return View(new CookListModel { Cooks = cooks });
    }
    
    [HttpGet]
    [Route("{username}")]
    public IActionResult Cook(string username)
    {
        StringValues searchValues = HttpContext.Request.Query["tab"];
        string tab = searchValues.Any() ? searchValues.ToString() : "Recipes";
        switch (tab)
        {
            case "Recipes":
                ViewBag.Recipes = _cookService.GetRecipesByUsername(username);
                break;
            case "CookReviews":
                ViewBag.CookReviews = _cookService.GetReviewsForUsername(username);
                break;
        }
        ViewBag.IsOwner = _securityHandler.IsUser(username);
        return View(new CookModel { Cook = _cookService.GetByUserName(username)! });
    }

    [HttpGet]
    [Route("{username}/Edit")]
    public IActionResult EditCook(string username)
    {
        return !_securityHandler.IsUser(username) 
            ? _securityHandler.RedirectToNoPermission() 
            : View(EditCookModel.FromCook(_cookService.GetByUserName(username)!));
    }
    
    [HttpPost]
    [Route("{username}/Edit/")]
    public IActionResult EditCook(string username, EditCookModel model)
    {
        List<string> errors = RegisterHandler.GetErrors(new RegisterModel { Username = model.Username, Fullname = model.Fullname, Email = model.Email })
            .Where(s => !s.ToLower().Contains("password") && !s.ToLower().Contains("username")).ToList();
        if (!(Uri.TryCreate(model.ImageUrl, UriKind.Absolute, out Uri? uriResult) 
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
        {
            errors.Add("Profile picture URL must be a valid URL. (don't forget http:// or https://)");
        }
        if (!errors.Any())
        {
            ViewBag.SuccessMessage = "Successfully saved changes.";
            Cook cook = _cookService.GetByUserName(username)!;
            _cookService.Update(new Cook.Builder()
                .WithId(cook.Id)
                .WithUsername(cook.Username)
                .WithFullname(model.Fullname)
                .WithImageUrl(model.ImageUrl)
                .WithCredential(new Credential(
                    model.Email, 
                    cook.Credential.Password, 
                    cook.Credential.UpdatedAt))
                .Build());
        }
        ViewBag.ErrorMessages = errors;
        return _securityHandler.IsUser(username)
            ? View(model)
            : _securityHandler.RedirectToNoPermission();
    }

    [HttpPost]
    [Route("{username}/Delete")]
    public IActionResult Delete(string username)
    {
        if (_securityHandler.IsUser(username))
        {
            _cookService.Delete(username);
            return _securityHandler.LogoutAndRedirectToHome();
        }
        return _securityHandler.RedirectToNoPermission();
    }
}