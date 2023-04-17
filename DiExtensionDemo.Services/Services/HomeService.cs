namespace DiExtensionDemo.Services;

/// <summary>
/// Sample service to display home information.
/// </summary>
public interface IHomeService
{
    /// <summary>
    /// Get a message to display.
    /// </summary>
    /// <returns>Message to display.</returns>
    string GetMessage();
}

/// <inheritdoc />
public class HomeService : IHomeService
{
    /// <inheritdoc />
    public string GetMessage() => "Welcome Home!";
}