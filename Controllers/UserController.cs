using Microsoft.AspNetCore.Mvc;
using TestAPI.Services;

namespace TestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{

    UserService _UserService;

    public UserController(UserService userService){
        _UserService = userService;
    }

    [HttpGet]
    [Route("/Users/GetAllUsers")]
    public IActionResult Get()
    {
        return Ok(_UserService.getUsers());
    }

    [HttpGet]
    [Route("/Users/GetUser")]
    public IActionResult GetById(Guid UserId)
    {
        return Ok(_UserService.getUserById(UserId));
    }

    [HttpPost]
    [Route("/Users/AddNewUser")]
    public IActionResult PostNewUser(string userName, string userPassword)
    {
        _UserService.newUser(userName, userPassword);

        return Ok();
    }

    [HttpPost]
    [Route("/Users/LoginUser")]
    public IActionResult LoginUser(string userName, string userPassword)
    {
        
        return Ok(_UserService.loginUser(userName, userPassword));
    }
}
