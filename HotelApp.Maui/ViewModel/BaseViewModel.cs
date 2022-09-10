namespace HotelApp.Maui.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool _isBusy;

    [ObservableProperty]
    string lastNameInput; //bind to MainPage last name input entry

    public bool IsNotBusy => !IsBusy;
}
