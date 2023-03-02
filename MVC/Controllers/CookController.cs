using BLL.Data.Cook;
using BLL.Entities;
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
    
    // GET Cook
    [Route("Cook")]
    public IActionResult Index()
    {
        List<Cook> cooks = _cookService.GetAll();
        return View(new CookListModel { Cooks = cooks });
    }
    
    // GET Cook/Cook/Guid
    [Route("Cook/{username}")]
    public IActionResult Cook(string username)
    {
        Cook cook = _cookService.GetByUserName(username);
        return View(new CookModel { Cook = cook });
    }
}