using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;


namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly IDatabaseData _db;

        public RoomTypesController(IDatabaseData db)
        {
           _db = db;
        }


        // POST api/<RoomTypesController>
        [HttpPost]
        public RoomTypeModel Post([FromBody] int value)
        {
            return _db.GetRoomTypeById(value);
        }

    }
}
