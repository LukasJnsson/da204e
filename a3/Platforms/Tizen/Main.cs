using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Solution_Assignment_3;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MAUIAPP.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}

