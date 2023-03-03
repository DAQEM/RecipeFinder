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
        Cook cook = _cookService.GetByUserName(username);
        return View(new CookModel { Cook = cook });
    }
}