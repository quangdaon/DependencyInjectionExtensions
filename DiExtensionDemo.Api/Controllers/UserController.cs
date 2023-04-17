using DiExtensionDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiExtensionDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public string Get() => _userService.Get();

    [HttpPost]
    public IActionResult Set(string value)
    {
        _userService.Set(value);
        return Created("/User", value);
    }

    [HttpGet("[action]")]
    public string Greet() => _userService.Greet();
}
