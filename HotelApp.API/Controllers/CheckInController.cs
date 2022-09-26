using HotelAppLibrary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelApp.API.Models;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly IDatabaseData _db;

        public CheckInController(IDatabaseData db)
        {
            _db = db;
        }


        [HttpPost]
        public void Post(CheckIn checkIn)
        {
            try
            {
                _db.CheckInGuest(checkIn.Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
          
        }
    }
}
