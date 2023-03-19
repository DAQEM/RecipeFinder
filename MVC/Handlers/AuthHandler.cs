using Microsoft.AspNetCore.Mvc;
using MVC.Controllers;

namespace MVC.Handlers;

public class AuthHandler<T> where T : BaseController<T>
{
    private const string UsernameSessionKey = "Username";
    private readonly BaseController<T> _controller;
    
    public AuthHandler(BaseController<T> controller)
    {
        _controller = controller;
    }
    
    public bool IsLoggedIn()
    {
        return GetSessionUsername() != null;
    }
    
    public void Login(string username)
    {
        _controller.HttpContext.Session.SetString(UsernameSessionKey, username);
    }
    
    public void Logout()
    {
        _controller.HttpContext.Session.Remove(UsernameSessionKey);
    }

    public bool IsUser(string username)
    {
        return IsLoggedIn() && string.Equals(GetSessionUsername(), username, StringComparison.CurrentCultureIgnoreCase);
    }

    public string? GetSessionUsername()
    {
        return _controller.HttpContext.Session.GetString(UsernameSessionKey);
    }
}