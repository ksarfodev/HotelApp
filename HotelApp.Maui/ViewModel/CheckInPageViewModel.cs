namespace HotelApp.Maui.ViewModel;

//Add QueryProperty
[QueryProperty(nameof(BookingFullModel), "CheckInPage")]
public partial class CheckInPageViewModel:BaseViewModel
{
    private readonly CheckInService _bookingService;
    private readonly BookingViewModel _bvm;

    public CheckInPageViewModel(CheckInService bookingService,BookingViewModel bvm)
    {
        _bookingService = bookingService;
        _bvm = bvm;
    }

    [ObservableProperty]
    BookingFullModel bookingFullModel;

    //CheckInPage.xaml Confirm Check-In button

    [RelayCommand]
    async Task BookGuestAsync(CheckInPageViewModel model)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await _bookingService.BookGuest(model.BookingFullModel);

            _bvm.Bookings.Clear();
            _bvm.LastNameInput = "";
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get bookings: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
