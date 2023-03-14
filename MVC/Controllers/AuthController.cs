using BLL.Data.Auth;
using BLL.Exceptions;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using MVC.Handlers;
using MVC.Models.Auth;
using MVC.Models.Cook;

namespace MVC.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;
    private readonly AuthHandler _authHandler;
    
    public AuthController(IAuthService service)
    {
        _authService = service;
        _authHandler = new AuthHandler(this);
    }
    
    [HttpGet]
    [Route("Login")]
    public IActionResult Login()
    {
        return _authHandler.IsLoggedIn() 
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
        return _authHandler.LogoutAndRedirectToHome();
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
                return _authHandler.LoginAndRedirectToHome(username);
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
                    return _authHandler.LoginAndRedirectToHome(model.Username);
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

    [HttpGet]
    [Route("ChangePassword")]
    public IActionResult ChangePassword()
    {
        return !_authHandler.IsLoggedIn() 
            ? _authHandler.RedirectToNoPermission() 
            : View(new ChangePasswordModel { Username = _authHandler.GetSessionUsername()! });
    }
    
    [HttpPost]
    [Route("ChangePassword")]
    public IActionResult ChangePassword(ChangePasswordModel model)
    {
        if (ModelState.IsValid)
        {
            List<string> errors = ChangePasswordHandler.GetErrors(model);
            if (!errors.Any())
            {
                try
                {
                    _authService.ChangePassword(model.Username, model.OldPassword, model.NewPassword);
                    return _authHandler.LoginAndRedirectToHome(model.Username);
                }
                catch (Exception e) when (e is WrongPasswordException or UsernameNotFoundException)
                {
                    errors.Add(e.Message);
                }
            }
            ViewBag.ErrorMessages = errors;
        }
        return View(model);
    }
}