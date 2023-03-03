using BLL.Data.Cook;
using BLL.Entities;
using BLL.Entities.Cook;
using DAL.Repositories.Cook;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Cook;

namespace MVC.Controllers;

public class CookController : Controller
{
    private readonly CookService _cookService;
    
    public CookController()
    {
        _cookService = new CookService(new CookRepository());
    }
    
    [HttpGet]
    [Route("Cook")]
    public IActionResult Index()
    {
        List<Cook> cooks = _cookService.GetAll();
        return View(new CookListModel { Cooks = cooks });
    }
    
    [HttpGet]
    [Route("Cook/{username}")]
    public IActionResult Cook(string username)
    {
        Cook? cook = _cookService.GetByUserName(username);
        return View(new CookModel { Cook = cook });
    }

    [HttpGet]
    [Route("Cook/{username}/Edit")]
    public IActionResult EditCook(string username)
    {
        if (HttpContext.Session.GetString("username") != username)
        {
            return RedirectToAction("NoPermission", "Security");
        }
        Cook? cook = _cookService.GetByUserName(username);
        if (cook == null) return View();
        return View(new EditCookModel { Username = cook.Username, Fullname = cook.Fullname, ImageUrl = cook.ImageUrl, Email = cook.Credential.Email});
    }
    
    [HttpPost]
    [Route("Cook/{username}/Edit/")]
    public IActionResult EditCook(string username, EditCookModel model)
    {
        if (HttpContext.Session.GetString("username") != username)
        {
            return RedirectToAction("NoPermission", "Security");
        }
        Console.WriteLine("model: " + model.Username);
        Console.WriteLine("link: " + username);
        return View(model);
    }
}