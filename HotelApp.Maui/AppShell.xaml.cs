namespace HotelApp.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //Register CheckIn page for routing
        Routing.RegisterRoute(nameof(CheckInPage),typeof(CheckInPage));
    }
}