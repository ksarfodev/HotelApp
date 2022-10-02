using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HotelAppLibrary.Data;
using HotelApp.AzureFunction.Models;

namespace HotelApp.AzureFunction.Functions
{
    public class Bookings
    {
        private readonly IDatabaseData _db;
        public Bookings(IDatabaseData db)
        {
            _db = db;
        }
        [FunctionName("Bookings")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string result = String.Empty;
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                NewBooking booking = JsonConvert.DeserializeObject<NewBooking>(requestBody);

                _db.BookGuest(booking.FirstName, booking.LastName, booking.StartDate, booking.EndDate, booking.RoomTypeId);

                result = $"The query executed successfully.";

                log.LogInformation(result);

            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
                result = ex.Message;
            }

            return new OkObjectResult(result);
        }
    }
}
