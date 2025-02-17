using CommunityToolkit.Maui;
using GuildsApp.Pages;
using GuildsApp.Services;
using GuildsApp.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Platform;

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


#if ANDROID
            
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
            });
#endif

        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<GuildServices>();

        builder.Services.AddSingleton<GuildsViewModel>();
        builder.Services.AddSingleton<GuildsPage>();
        builder.Services.AddSingleton<ListOfGuildsViewModel>();
        builder.Services.AddSingleton<ListOfGuildsPage>();
        builder.Services.AddSingleton<CreateGuildPage>();
        builder.Services.AddSingleton<CreateGuildViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
