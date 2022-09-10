using HotelApp.Blazor.Models;

namespace HotelApp.Blazor.Services
{
    public interface IApiService
    {
        Task<HttpResponseMessage> BookGuest();
        Task<List<RoomTypeModel>> GetAvalilableRooms();
        Task GetRoomTypeById();
    }
}