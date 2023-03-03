using System.Net.Mail;
using BLL.Data.Auth;
using BLL.Exceptions;
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
    
    [HttpGet]
    [Route("Login")]
    public IActionResult Login()
    {
        return View();
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
        HttpContext.Session.Remove(UsernameSessionKey);
        return RedirectToAction("Index", "Home");
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
                HttpContext.Session.SetString(UsernameSessionKey, username);
                return RedirectToAction("Index", "Home");
            } 
        }
        ViewBag.ErrorMessage = "Invalid username or password.";
        return View(model);
        
    }

    [HttpPost]
    [Route("Register")]
    public IActionResult Register(RegisterModel model)
    {
        model.TrimAll();
        
        if (HasError(model)) return View(model);

        try
        {
            _authService.Register(model.Username, model.Fullname, model.Email, model.Password);

            HttpContext.Session.SetString(UsernameSessionKey, model.Username);

            return RedirectToAction("Index", "Home");
        }
        catch (Exception e) 
            when(e is UsernameTakenException or EmailTakenException)
        {
            ViewBag.ErrorMessage = e.Message;
            return View(model);
        }
    }

    private bool HasError(RegisterModel model)
    {
        bool hasError = false;
        hasError = CheckPasswordMatch(model, hasError);
        hasError = CheckPasswordLength(model, hasError);
        hasError = CheckUsernameLength(model, hasError);
        hasError = CheckFullNameLength(model, hasError);
        hasError = CheckEmailValid(model, hasError);

        return hasError;
    }

    private bool CheckEmailValid(RegisterModel model, bool hasError)
    {
        try
        {
            if (model.Email == string.Empty ||
                model.Email.EndsWith(".") ||
                new MailAddress(model.Email).Address != model.Email)
            {
                ViewBag.ErrorMessage = "Email is not valid.";
                hasError = true;
            }
        } catch (FormatException)
        {
            ViewBag.ErrorMessage = "Email is not valid.";
            hasError = true;
        }

        return hasError;
    }

    private bool CheckFullNameLength(RegisterModel model, bool hasError)
    {
        if (model.Fullname.Length < 3)
        {
            ViewBag.ErrorMessage = "Full name must be at least 3 characters long.";
            hasError = true;
        }

        return hasError;
    }

    private bool CheckUsernameLength(RegisterModel model, bool hasError)
    {
        if (model.Username.Length < 3)
        {
            ViewBag.ErrorMessage = "Username must be at least 3 characters long.";
            hasError = true;
        }

        return hasError;
    }

    private bool CheckPasswordLength(RegisterModel model, bool hasError)
    {
        if (model.Password.Length < 8)
        {
            ViewBag.ErrorMessage = "Password must be at least 8 characters long.";
            hasError = true;
        }

        return hasError;
    }

    private bool CheckPasswordMatch(RegisterModel model, bool hasError)
    {
        if (model.Password != model.ConfirmPassword)
        {
            ViewBag.ErrorMessage = "Passwords do not match.";
            hasError = true;
        }

        return hasError;
    }
}