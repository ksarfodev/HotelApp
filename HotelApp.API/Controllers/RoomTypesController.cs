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
            RoomTypeModel result = new();

            try
            {
                result = _db.GetRoomTypeById(value);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            return result;
        }

    }
}
