using HotelApp.BlazorWasm.Models;

namespace HotelApp.BlazorWasm.Services
{
    public interface IApiService
    {
        Task<HttpResponseMessage> BookGuest();
        Task<List<RoomTypeModel>> GetAvalilableRooms();
        Task GetRoomTypeById();
    }
}