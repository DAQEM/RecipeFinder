using Microsoft.AspNetCore.Mvc;

namespace MVC.Handlers;

public class RedirectionHandler
{
    private readonly Controller _controller;
    
    public RedirectionHandler(Controller controller)
    {
        _controller = controller;
    }
    
    public IActionResult Home => _controller.RedirectToAction("Index", "Home");
}