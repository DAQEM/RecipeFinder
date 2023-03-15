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
    private readonly AuthHandler _authHandler;
    
    public CookController(ILogger<CookController> logger, ICookService service) : base(logger)
    {
        _cookService = service;
        _authHandler = new AuthHandler(this);
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
        ViewBag.IsOwner = _authHandler.IsUser(username);
        return View("CookRecipes", new CookModel { Cook = _cookService.GetByUsernameWithRecipes(username)!});
    }
    
    [HttpGet]
    [Route("{username}/Reviews")]
    public IActionResult CookReviews(string username)
    {
        ViewBag.IsOwner = _authHandler.IsUser(username);
        return View("CookReviews", new CookModel { Cook = _cookService.GetByUsernameWithCookReviews(username)!});
    }
    
    [HttpGet]
    [Route("{username}/Edit")]
    public IActionResult EditCook(string username)
    {
        return !_authHandler.IsUser(username) 
            ? _authHandler.RedirectToNoPermission() 
            : View(EditCookModel.FromCook(_cookService.GetByUsername(username)!));
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
            Cook cook = _cookService.GetByUsername(username)!;
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
        return _authHandler.IsUser(username)
            ? View(model)
            : _authHandler.RedirectToNoPermission();
    }

    [HttpPost]
    [Route("{username}/Delete")]
    public IActionResult Delete(string username)
    {
        if (_authHandler.IsUser(username))
        {
            _cookService.Delete(username);
            return _authHandler.LogoutAndRedirectToHome();
        }
        return _authHandler.RedirectToNoPermission();
    }
}