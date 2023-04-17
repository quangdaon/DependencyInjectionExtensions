namespace DiExtensionDemo.Services;

/// <summary>
/// Sample service to display a greeting.
/// </summary>
public interface IGreetingService
{
  /// <summary>
  /// Displays a greeting for a given name.
  /// </summary>
  /// <param name="name">Name to greet.</param>
  /// <returns>Greeting with specified name.</returns>
  string Greet(string name);
}

/// <inheritdoc />
public class GreetingService : IGreetingService
{
  /// <inheritdoc />
  public string Greet(string name) => $"Hello, {name}!";
}
