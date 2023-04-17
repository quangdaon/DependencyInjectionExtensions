using DiExtensionDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiExtensionDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{

    private readonly ILogger<HomeController> _logger;
    private readonly IHomeService _homeService;

    public HomeController(ILogger<HomeController> logger, IHomeService homeService)
    {
        _logger = logger;
        _homeService = homeService;
    }

    [HttpGet]
    public string Get() => _homeService.GetMessage();
}
