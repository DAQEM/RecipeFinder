using BLL.Data.Cook;
using BLL.Entities;
using DAL.Cook;
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
    public IActionResult Index()
    {
        List<Cook> cooks = _cookService.GetAll();
        return View(new CookListModel { Cooks = cooks });
    }
    
    // GET Cook/Cook/Guid
    public IActionResult Cook(Guid id)
    {
        Cook cook = _cookService.GetById(id);
        return View(new CookModel { Cook = cook });
    }
}