using CommunityToolkit.Maui;
using GuildsApp.Pages;
using GuildsApp.Services;
using GuildsApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace GuildsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("FredokaBold.ttf", "FredokaBold");
                fonts.AddFont("FredokaLight.ttf", "FredokaLight");
                fonts.AddFont("FredokaMedium.ttf", "FredokaMedium");
                fonts.AddFont("FredokaRegular.ttf", "FredokaRegular");
                fonts.AddFont("FredokaSemiBold.ttf", "FredokaSemiBold");

            }).ConfigureMauiHandlers(handlers =>
				{

#if ANDROID
                handlers.AddHandler(typeof(Shell), typeof(Platforms.Android.CustomeShell));
#endif

				});
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<GuildServices>();

        builder.Services.AddSingleton<GuildsViewModel>();
        builder.Services.AddSingleton<GuildsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
