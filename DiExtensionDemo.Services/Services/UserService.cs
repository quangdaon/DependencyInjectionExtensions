namespace DiExtensionDemo.Services;

/// <summary>
/// Sample service to manage a user.
/// </summary>
public interface IUserService
{
  /// <summary>
  /// Get the user's name.
  /// </summary>
  /// <returns>User's name.</returns>
  string Get();
  
  /// <summary>
  /// Greet the user.
  /// </summary>
  /// <returns>Greeting with user's name.</returns>
  string Greet();
  
  /// <summary>
  /// Set the user's name.
  /// </summary>
  /// <param name="user">Name to the the user's name to.</param>
  void Set(string user);
}

/// <inheritdoc />
public class UserService : IUserService
{
  private readonly IGreetingService _greetingService;
  private static string _user = "World";

  public UserService(IGreetingService greetingService)
  {
    _greetingService = greetingService;
  }

  /// <inheritdoc />
  public void Set(string user) => _user = user;
  
  /// <inheritdoc />
  public string Get() => _user;

  /// <inheritdoc />
  public string Greet() => _greetingService.Greet(_user);
}