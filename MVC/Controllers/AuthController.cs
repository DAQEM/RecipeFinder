using BLL.Data.Auth;
using DAL.Repositories.Auth;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Auth;

namespace MVC.Controllers;

public class AuthController : Controller
{
    private const string UsernameSessionKey = "Username";
    private readonly AuthService _authService;
    
    public AuthController()
    {
        _authService = new AuthService(new AuthRepository());
    }
    
    [Route("Login")]
    public IActionResult Login()
    {
        return View();
    }
    
    [Route("Register")]
    public IActionResult Register()
    {
        return View();
    }
    
    [Route("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove(UsernameSessionKey);
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Route("Login")]
    public IActionResult Login(LoginModel model)
    {
        string? username = _authService.Login(model.Username, model.Password);

        if (username != null)
        {
            HttpContext.Session.SetString(UsernameSessionKey, username);
            return RedirectToAction("Index", "Home");
        }
        ViewBag.ErrorMessage = "Invalid username or password.";
        return View(model);
        
    }

    [HttpPost]
    [Route("Register")]
    public IActionResult Register(RegisterModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            ViewBag.ErrorMessage = "Passwords do not match.";
            return View(model);
        }
        
        _authService.Register(model.Username, model.FullName, model.Email, model.Password);
        
        HttpContext.Session.SetString(UsernameSessionKey, model.Username);

        return RedirectToAction("Index", "Home");
    }
}