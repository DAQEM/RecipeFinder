using BLL.Data.Cook;
using BLL.Entities.Cook;
using BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using MVC.Handlers;

namespace MVC.Controllers;

public class BaseController<T> : Controller where T : BaseController<T>
{
    private ILogger<T>? _logger;
    private readonly AuthHandler<T> _authHandler;
    private readonly RedirectionHandler _redirectionHandler;
    
    public BaseController()
    {
        _authHandler = new AuthHandler<T>(this);
        _redirectionHandler = new RedirectionHandler(this);
    }

    protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
    protected AuthHandler<T> Auth => _authHandler;
    public new RedirectionHandler Redirect => _redirectionHandler;

    protected Cook? GetViewer(ICookService cookService)
    {
        try {
            return Auth.IsLoggedIn() ? cookService.GetByUsernameWithFollowers(Auth.GetSessionUsername()!) : null;
        }
        catch (NotFoundException) {
            return null;
        }
    }
}