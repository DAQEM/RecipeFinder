using System.Net.Mail;
using BLL.Data.Auth;
using BLL.Exceptions;
using DAL.Repositories.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC.Handlers;
using MVC.Models.Auth;

namespace MVC.Controllers;

public class AuthController : Controller
{
    private readonly AuthService _authService;
    private readonly SecurityHandler _securityHandler;
    
    public AuthController()
    {
        _authService = new AuthService(new AuthRepository());
        _securityHandler = new SecurityHandler(this);
    }
    
    [HttpGet]
    [Route("Login")]
    public IActionResult Login()
    {
        return _securityHandler.IsLoggedIn() 
            ? RedirectToAction("Index", "Home") 
            : View();
    }
    
    [HttpGet]
    [Route("Register")]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpGet]
    [Route("Logout")]
    public IActionResult Logout()
    {
        return _securityHandler.LogoutAndRedirectToHome();
    }

    [HttpPost]
    [Route("Login")]
    public IActionResult Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            string? username = _authService.Login(model.Username, model.Password);

            if (username != null)
            {
                return _securityHandler.LoginAndRedirectToHome(username);
            } 
        }
        ViewBag.ErrorMessage = "Invalid username or password.";
        return View(model);
        
    }

    [HttpPost]
    [Route("Register")]
    public IActionResult Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            List<string> errors = RegisterHandler.GetErrors(model);
            if (!errors.Any())
            {
                try
                {
                    _authService.Register(model.Username, model.Fullname, model.Email, model.Password);
                    return _securityHandler.LoginAndRedirectToHome(model.Username);
                }
                catch (Exception e) when (e is UsernameTakenException or EmailTakenException)
                {
                    errors.Add(e.Message);
                }
            }
            ViewBag.ErrorMessages = errors;
        }
        return View(model);
    }

    
}