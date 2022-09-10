namespace HotelApp.Maui;

public static class MauiProgram
{

   
    public static IServiceProvider Services { get; private set; }
    public static MauiApp CreateMauiApp()
    {

        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddSingleton<CheckInPage>();
        builder.Services.AddSingleton<CheckInPageViewModel>();
        builder.Services.AddSingleton<CheckInService>();
        builder.Services.AddSingleton<BookingViewModel>();

        builder.Services.AddHttpClient();


        var a = Assembly.GetExecutingAssembly();

        //Add appsettings.json as embedded resource
        using var stream = a.GetManifestResourceStream("HotelApp.Maui.appsettings.json");

        var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();


        builder.Configuration.AddConfiguration(config);

        var app = builder.Build();

        //optional
        Ioc.Default.ConfigureServices
        (
            app.Services
        );

     
        Services = app.Services;

        return app;
    }
}