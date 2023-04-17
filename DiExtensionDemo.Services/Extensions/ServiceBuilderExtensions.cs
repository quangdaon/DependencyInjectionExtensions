using Microsoft.Extensions.DependencyInjection;

namespace DiExtensionDemo.Services.Extensions;

public static class ServiceBuilderExtensions
{
    /// <summary>
    /// Add all dependencies provided by the services package.
    /// </summary>
    /// <param name="services">Dependency injection container.</param>
    /// <seealso cref="IHomeService"/>
    /// <seealso cref="IUserService"/>
    /// <seealso cref="IGreetingService"/>
    public static void AddDemo(this IServiceCollection services)
    {
        services.AddTransient<IHomeService, HomeService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IGreetingService, GreetingService>();
    }

    /// <summary>
    /// Register dependencies required by HomeService
    /// </summary>
    /// <param name="services">Dependency injection container.</param>
    /// <seealso cref="IHomeService"/>
    public static void AddHome(this IServiceCollection services)
    {
        services.AddTransient<IHomeService, HomeService>();
    }

    /// <summary>
    /// Register dependencies required by UserService
    /// </summary>
    /// <param name="services">Dependency injection container.</param>
    /// <seealso cref="IUserService"/>
    /// <seealso cref="IGreetingService"/>
    public static void AddUser(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IGreetingService, GreetingService>();
    }
}