using DiExtensionDemo.Services;
using DiExtensionDemo.Services.Extensions;

namespace DiExtensionDemo.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Boilerplate
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        #endregion

        #region Service Registration Strategies (Important Stuff)
        AddServicesWithinApiProject(builder.Services);
        // AddServicesUsingServiceExtension(builder.Services);
        // AddServicesWithGranularDefinitions(builder.Services);
        #endregion

        # region More Boilerplate
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
        #endregion
    }
    
    /// <summary>
    /// Option #1 (Status Quo): API is responsible for managing its own services.
    /// </summary>
    /// <param name="services"></param>
    private static void AddServicesWithinApiProject(IServiceCollection services)
    {
        services.AddTransient<IHomeService, HomeService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IGreetingService, GreetingService>();
    }
    
    /// <summary>
    /// Option #2: Service package defines its own dependencies. 
    /// </summary>
    /// <param name="services"></param>
    private static void AddServicesUsingServiceExtension(IServiceCollection services)
    {
        services.AddDemo();
    }
    
    /// <summary>
    /// Option #3: Service package defines a dependency tree; API is responsible for adding individual "packages." 
    /// </summary>
    /// <param name="services"></param>
    private static void AddServicesWithGranularDefinitions(IServiceCollection services)
    {
        services.AddHome();
        services.AddUser();
    }
}
