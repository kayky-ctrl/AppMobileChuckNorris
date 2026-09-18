using AppMobileChuckNorris.Services;
using AppMobileChuckNorris.ViewModels;
using Microsoft.Extensions.Logging;
using AppMobileChuckNorris.Views;

namespace AppMobileChuckNorris
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<IChuckService, ChuckService>();
            builder.Services.AddTransient<ChuckNorrisViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<IHarryPoterService, HarryPoterService>();
            builder.Services.AddTransient<PotterViewModel>();
            builder.Services.AddTransient<PotterPage>();


            return builder.Build();
        }
    }
}
