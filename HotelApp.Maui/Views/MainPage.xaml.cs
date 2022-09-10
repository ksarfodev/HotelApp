namespace HotelApp.Maui;

public partial class MainPage : ContentPage
{
    public MainPage(BookingViewModel bookingsViewModel)
    {

        InitializeComponent();

        BindingContext = bookingsViewModel;
    }



}