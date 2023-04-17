namespace DiExtensionDemo.Services;

public interface IUserService
{
  string Get();
  string Greet();
  void Set(string user);
}

public class UserService : IUserService
{
  private readonly IGreetingService _greetingService;
  private static string _user = "World";

  public UserService(IGreetingService greetingService)
  {
    _greetingService = greetingService;
  }

  public void Set(string user) => _user = user;
  public string Get() => _user;
  public string Greet() => _greetingService.Greet(_user);
}