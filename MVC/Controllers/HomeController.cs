using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class HomeController : BaseController<HomeController>
{
    
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("Privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    [Route("Error/{statusCode}")]
    public IActionResult Error(int statusCode)
    {
        string errorMessage = statusCode switch
        {
            401 => "You are not authorized to view this page.",
            404 => "The page you are looking for does not exist.",
            _ => "Something went wrong."
        };
        return View(new ErrorViewModel { StatusCode = statusCode, ErrorMessage = errorMessage });
    }
}