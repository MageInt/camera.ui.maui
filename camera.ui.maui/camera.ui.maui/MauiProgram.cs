using camera.ui.maui.Interfaces;
using camera.ui.maui.Pages;
using camera.ui.maui.Services;
using camera.ui.maui.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace camera.ui.maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .RegisterAppServices()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IWebService, WebService>();

            return mauiAppBuilder;
        }


        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<CamerasPage>();
            mauiAppBuilder.Services.AddScoped<LoginPage>();
           
            return mauiAppBuilder;
        }
    }
}
