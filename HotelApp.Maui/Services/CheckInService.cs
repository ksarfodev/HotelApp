using Microsoft.Maui.Controls;

namespace HotelApp.Maui.Services;

public class CheckInService
{

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;
   
    List<BookingFullModel> _bookingsList = new();

    string _apiUrlBookingSearch = string.Empty;
    string _apiUrlCheckIn = string.Empty;
    bool _isAzureApi = false;
    public CheckInService( IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _httpClientFactory = httpClientFactory;
        _config = config;
      
        _apiUrlBookingSearch = _config.GetValue<string>("BaseApiUrl") + "bookingsearch";
        _apiUrlCheckIn = _config.GetValue<string>("BaseApiUrl") + "checkin";
       
    }
  

    public async Task<List<BookingFullModel>> GetBookings(string lastName)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();


            var response = await client.PostAsync(_apiUrlBookingSearch, new StringContent(JsonSerializer.Serialize(new LastNameSearch { LastName = lastName }),
                Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string responseText = await response.Content.ReadAsStringAsync();


                _bookingsList = JsonSerializer.Deserialize<List<BookingFullModel>>(responseText, options);

            }
            else
            {
                Console.WriteLine($"Error: {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
       
        return _bookingsList;
    }

    public async Task BookGuest(BookingFullModel model)
    {
        try
        {
            var newCheckIn = new CheckIn { Id = model.Id };

            var client = _httpClientFactory.CreateClient();
          

            var response = await client.PostAsync(
               _apiUrlCheckIn,
                new StringContent(JsonSerializer.Serialize(newCheckIn), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert("Checkin Status", "Congrats, you're checked in!", response.ReasonPhrase);
               await Shell.Current.GoToAsync("..");


                
            }
            else
            {
                await Shell.Current.DisplayAlert("Status:", response.ReasonPhrase, "OK");
            }

        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }
       
    }
}
