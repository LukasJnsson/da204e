/* 
Lukas Jönsson
16/10-2023
*/

using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
namespace Solution_Assignment_6;


public static class MAUIAPP
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<MainForm>();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
	}
}