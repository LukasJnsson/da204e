using Android.App;
using Android.Runtime;

namespace Solution_Assignment_4_PartyOrganizer;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MAUIAPP.CreateMauiApp();
}