using Microsoft.AspNetCore.Mvc;

namespace MVC.Handlers;

public class AuthHandler
{
    private const string UsernameSessionKey = "Username";
    private readonly Controller _controller;
    
    public AuthHandler(Controller controller)
    {
        _controller = controller;
    }
    
    public bool IsLoggedIn()
    {
        return GetSessionUsername() != null;
    }
    
    public IActionResult LoginAndRedirectToHome(string username)
    {
        _controller.HttpContext.Session.SetString(UsernameSessionKey, username);
        return RedirectToHome();
    }
    
    public IActionResult LogoutAndRedirectToHome()
    {
        _controller.HttpContext.Session.Remove(UsernameSessionKey);
        return RedirectToHome();
    }
    
    private IActionResult RedirectToHome()
    {
        return _controller.RedirectToAction("Index", "Home");
    }

    public bool IsUser(string username)
    {
        return IsLoggedIn() && string.Equals(GetSessionUsername(), username, StringComparison.CurrentCultureIgnoreCase);
    }
    
    public IActionResult RedirectToNoPermission()
    {
        return _controller.RedirectToAction("NoPermission", "Security");
    }
    
    public string? GetSessionUsername()
    {
        return _controller.HttpContext.Session.GetString(UsernameSessionKey);
    }
}