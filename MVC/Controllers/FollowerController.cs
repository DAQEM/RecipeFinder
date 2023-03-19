using BLL.Data.Cook;
using BLL.Data.Cook.Follower;
using BLL.Entities.Cook;
using BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class FollowerController : BaseController<FollowerController>
{
    private readonly ICookService _cookService;
    private readonly IFollowerService _followerService;
    
    public FollowerController(ICookService cookService, IFollowerService followerService)
    {
        _cookService = cookService;
        _followerService = followerService;
    }
    
    [HttpPost]
    [Route("Follow/{followingId}")]
    public IActionResult Follow(Guid followingId)
    {
        if (!Auth.IsLoggedIn()) return Unauthorized();
        try
        {
            Cook cook = _cookService.GetByUsername(Auth.GetSessionUsername()!);
            Cook following = _cookService.GetById(followingId);
            _followerService.Add(cook, following);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPost]
    [Route("Unfollow/{followingId}")]
    public IActionResult Unfollow(Guid followingId)
    {
        if (!Auth.IsLoggedIn()) return Unauthorized();
        try
        {
            Cook cook = _cookService.GetByUsername(Auth.GetSessionUsername()!);
            Cook following = _cookService.GetById(followingId);
            _followerService.Delete(cook, following);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        return Ok();
    }
}