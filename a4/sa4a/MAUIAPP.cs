﻿/* 
Lukas Jönsson
21/9-2023
*/

using Microsoft.Extensions.Logging;
namespace Solution_Assignment_4_PartyOrganizer;


public static class MAUIAPP
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
		return builder.Build();
	}
}