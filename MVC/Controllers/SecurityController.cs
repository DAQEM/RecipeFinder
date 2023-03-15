using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class SecurityController : BaseController<SecurityController>
{
    public SecurityController(ILogger<SecurityController> logger) : base(logger)
    {
    }
    
    [HttpGet]
    [Route("NoPermission")]
    public IActionResult NoPermission()
    {
        return View();
    }
}