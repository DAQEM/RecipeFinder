using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class SecurityController : Controller
{
    [HttpGet]
    [Route("NoPermission")]
    public IActionResult NoPermission()
    {
        return View();
    }
}