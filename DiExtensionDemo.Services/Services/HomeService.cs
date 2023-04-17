namespace DiExtensionDemo.Services;

public interface IHomeService
{
    string GetMessage();
}

public class HomeService : IHomeService
{
    public string GetMessage() => "Welcome Home!";
}