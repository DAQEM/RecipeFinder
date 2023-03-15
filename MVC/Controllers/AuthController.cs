using BLL.Data.Auth;
using BLL.Exceptions;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using MVC.Handlers;
using MVC.Models.Auth;
using MVC.Models.Cook;

namespace MVC.Controllers;

public class AuthController : BaseController<AuthController>
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService service)
    {
        _authService = service;
    }
    
    [HttpGet]
    [Route("Login")]
    public IActionResult Login()
    {
        return Auth.IsLoggedIn() 
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
        return Auth.LogoutAndRedirectToHome();
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
                return Auth.LoginAndRedirectToHome(username);
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
                    return Auth.LoginAndRedirectToHome(model.Username);
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
        return !Auth.IsLoggedIn() 
            ? Auth.RedirectToNoPermission() 
            : View(new ChangePasswordModel { Username = Auth.GetSessionUsername()! });
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
                    return Auth.LoginAndRedirectToHome(model.Username);
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