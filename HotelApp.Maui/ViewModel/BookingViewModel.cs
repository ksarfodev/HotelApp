namespace HotelApp.Maui.ViewModel;

public partial class BookingViewModel:BaseViewModel
{
    private readonly CheckInService _checkInService;

    public ObservableCollection<BookingFullModel> Bookings { get; set; } = new();

    public BookingViewModel(CheckInService checkInService)
    {
        _checkInService = checkInService;
    }

    //MainPage.xaml Search button

    [RelayCommand]
    public async Task GetBookingsAsync()
    {

        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var bookings = await _checkInService.GetBookings(LastNameInput);

            if (Bookings.Count != 0)
                Bookings.Clear();

            foreach (var booking in bookings)
                Bookings.Add(booking);

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

    //MainPage.xaml Check In button

    [RelayCommand]
    async Task CheckIn(BookingFullModel model)
    {
        await Shell.Current.GoToAsync("CheckInPage", new Dictionary<string, object>
        {
            {
                nameof(CheckInPage), model
            }
        });

     
    }
}
