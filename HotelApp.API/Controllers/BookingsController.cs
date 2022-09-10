using HotelApp.API.Models;
using HotelAppLibrary.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IDatabaseData _db;

        public BookingsController(IDatabaseData db)
        {
            _db = db;
        }


        [HttpPost]
        public void Post(NewBooking? booking)
        {
            _db.BookGuest(booking.FirstName, booking.LastName, booking.StartDate, booking.EndDate, booking.RoomTypeId);
        }
    }
}
