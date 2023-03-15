using Microsoft.AspNetCore.Mvc;
using MVC.Handlers;

namespace MVC.Controllers;

public class BaseController<T> : Controller where T : BaseController<T>
{
    private readonly ILogger<T> _logger;
    private readonly AuthHandler _authHandler;
    
    public BaseController(ILogger<T> logger)
    {
        _logger = logger;
        _authHandler = new AuthHandler(this);
    }
}