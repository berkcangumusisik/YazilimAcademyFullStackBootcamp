using Microsoft.Extensions.Logging;
using PasswordStorageApp.MobileClient.Services;
using Radzen;

namespace PasswordStorageApp.MobileClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            builder.Services.AddRadzenComponents();

            builder.Services.AddScoped<IToastService, RadzenToastManager>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://csharpjavadandahaiyi.tailwindcomponents.io/api/") });


#endif

            return builder.Build();
        }
    }
}
