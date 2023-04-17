using DiExtensionDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiExtensionDemo.Api.Controllers;

/// <summary>
/// Controller for managing user endpoints.
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    /// <summary>
    /// Instantiate the user controller.
    /// </summary>
    /// <param name="userService">Service to manage user content.</param>
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Get the user.
    /// </summary>
    /// <returns>User's name.</returns>
    [HttpGet]
    public string Get() => _userService.Get();

    /// <summary>
    /// Set the user's name.
    /// </summary>
    /// <param name="name">Name to change to.</param>
    /// <returns>User's name and created location.</returns>
    [HttpPost]
    public IActionResult Set(string name)
    {
        _userService.Set(name);
        return Created("/User", name);
    }

    /// <summary>
    /// Greet the user.
    /// </summary>
    /// <returns>Greeting with the user's name.</returns>
    [HttpGet("[action]")]
    public string Greet() => _userService.Greet();
}
