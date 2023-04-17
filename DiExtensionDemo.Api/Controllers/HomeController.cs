using DiExtensionDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiExtensionDemo.Api.Controllers;

/// <summary>
/// Controller for managing home endpoints.
/// </summary>
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IHomeService _homeService;

    /// <summary>
    /// Instantiate the home controller.
    /// </summary>
    /// <param name="homeService">Service to manage home content.</param>
    public HomeController(IHomeService homeService)
    {
        _homeService = homeService;
    }

    /// <summary>
    /// Get home message.
    /// </summary>
    /// <returns>Home message.</returns>
    [HttpGet]
    public string Get() => _homeService.GetMessage();
}
