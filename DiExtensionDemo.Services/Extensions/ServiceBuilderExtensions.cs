using Microsoft.Extensions.DependencyInjection;

namespace DiExtensionDemo.Services.Extensions;

public static class ServiceBuilderExtensions
{
    public static void AddDemo(this IServiceCollection services)
    {
        services.AddTransient<IHomeService, HomeService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IGreetingService, GreetingService>();
    }

    public static void AddHome(this IServiceCollection services)
    {
        services.AddTransient<IHomeService, HomeService>();
    }
    
    public static void AddUser(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IGreetingService, GreetingService>();
    }
}