using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class SecurityController : BaseController<SecurityController>
{
    
    [HttpGet]
    [Route("NoPermission")]
    public IActionResult NoPermission()
    {
        return View();
    }
}