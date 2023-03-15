using Microsoft.AspNetCore.Mvc;
using MVC.Handlers;

namespace MVC.Controllers;

public class BaseController<T> : Controller where T : BaseController<T>
{
    private ILogger<T>? _logger;
    private readonly AuthHandler _authHandler;
    private readonly RedirectionHandler _redirectionHandler;
    
    public BaseController()
    {
        _authHandler = new AuthHandler(this);
        _redirectionHandler = new RedirectionHandler(this);
    }

    protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
    protected AuthHandler Auth => _authHandler;
    protected new RedirectionHandler Redirect => _redirectionHandler;
}