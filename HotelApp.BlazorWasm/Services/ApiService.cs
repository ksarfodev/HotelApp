using HotelApp.BlazorWasm.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace HotelApp.BlazorWasm.Services
{
    public class ApiService : IApiService
    {
        private readonly RoomSelection _roomSelection;
        private readonly IHttpClientFactory _httpClientFactory;

        string _apiUrlRoomSearch = string.Empty;
        string _apiUrlRoomTypes = string.Empty;
        string _apiUrlBooking = string.Empty;
        bool _isAzureApi = false;

        public List<RoomTypeModel>? AvailableRoomTypes { get; set; }

        public ApiService(RoomSelection roomSelection, IHttpClientFactory httpClientFactory)
        {
            _roomSelection = roomSelection;
            _httpClientFactory = httpClientFactory;

            LoadConfig();
        }

        private void LoadConfig()
        {
            var builder = WebAssemblyHostBuilder.CreateDefault();

            WebAssemblyHostConfiguration config = builder.Configuration;

            _apiUrlRoomSearch = config.GetValue<string>("BaseApiUrl");
            _apiUrlRoomTypes = config.GetValue<string>("BaseApiUrl");
            _apiUrlBooking = config.GetValue<string>("BaseApiUrl");
            _isAzureApi = config.GetValue<bool>("AzureApi");
        }

        public async Task<List<RoomTypeModel>> GetAvalilableRooms()
        {
            try
            {
                DateRange dateRange = new DateRange()
                {
                    StartDate = _roomSelection.StartDate,
                    EndDate = _roomSelection.EndDate
                };

                var _client = _httpClientFactory.CreateClient();
 

                var response = await _client.PostAsync(
                   _apiUrlRoomSearch,
                      new StringContent(JsonSerializer.Serialize(dateRange), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string responseText = await response.Content.ReadAsStringAsync();
                    AvailableRoomTypes = JsonSerializer.Deserialize<List<RoomTypeModel>>(responseText, options);
                }
                else
                {
                    Debug.WriteLine(response.ReasonPhrase);
                    // _errorMessage = "Unable to search database.";

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
                // _errorMessage = "Unable to search database.";

            }
            return AvailableRoomTypes;
        }

        public async Task GetRoomTypeById()
        {
            try
            {
                var _client = _httpClientFactory.CreateClient();

                var response = await _client.PostAsync(_apiUrlRoomTypes, new StringContent(JsonSerializer.Serialize(_roomSelection.RoomType.Id),
                    Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string responseText = await response.Content.ReadAsStringAsync();
                    _roomSelection.RoomType = JsonSerializer.Deserialize<RoomTypeModel>(responseText, options);

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task<HttpResponseMessage> BookGuest()
        {
            NewBooking booking = new NewBooking()
            {
                FirstName = _roomSelection.FirstName,
                LastName = _roomSelection.LastName,
                StartDate = _roomSelection.StartDate.Date,
                EndDate = _roomSelection.EndDate.Date,
                RoomTypeId = _roomSelection.RoomType.Id
            };

            var _client = _httpClientFactory.CreateClient();

            var response = await _client.PostAsync(
               _apiUrlBooking,
                new StringContent(JsonSerializer.Serialize(booking), Encoding.UTF8, "application/json"));

            return response;
        }

    }
}
