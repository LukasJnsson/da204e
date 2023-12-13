using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Solution_Assignment_4_PartyOrganizer;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MAUIAPP.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}