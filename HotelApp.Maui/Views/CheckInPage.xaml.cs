using CommunityToolkit.Mvvm.Input;
using HotelApp.Maui.Services;
using HotelApp.Maui.ViewModel;
using System.Diagnostics;

namespace HotelApp.Maui;

public partial class CheckInPage : ContentPage
{
    public CheckInPage(CheckInPageViewModel page)
	{
		InitializeComponent();
  
        BindingContext = page;
    }
}