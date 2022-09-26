using HotelApp.API.Models;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;


namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingSearchController : ControllerBase
    {
        private readonly IDatabaseData _db;

        public BookingSearchController(IDatabaseData db)
        {
            _db = db;
        }

        // POST api/<BookingSearchController>
        [HttpPost]
        public List<BookingFullModel> Post([FromBody] LastNameSearch nameSearch)
        {
            List<BookingFullModel> result = new();
            try
            {
              result =  _db.SearchBookings(nameSearch.LastName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }
    }
}
