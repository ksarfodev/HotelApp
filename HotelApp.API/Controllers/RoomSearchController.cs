using HotelApp.API.Models;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomSearchController : ControllerBase
    {
        private readonly IDatabaseData _db;

        public RoomSearchController(IDatabaseData db)
        {
            _db = db;
        }

        [HttpPost]
        public List<RoomTypeModel> Post(DateRange range)
        {
            return _db.GetAvailableRoomTypes(range.StartDate, range.EndDate);
        }
    }
}
