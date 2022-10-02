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
using System.Collections.Generic;
using HotelAppLibrary.Models;

namespace HotelApp.AzureFunction.Functions
{
    public class BookingSearch
    {
        private readonly IDatabaseData _db;
        public BookingSearch(IDatabaseData db)
        {
            _db = db;
        }

        [FunctionName("BookingSearch")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<BookingFullModel> result = new();
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                LastNameSearch nameResult = JsonConvert.DeserializeObject<LastNameSearch>(requestBody);

                result = _db.SearchBookings(nameResult.LastName);

                log.LogInformation($"The query executed successfully.");

            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
            }

            return new OkObjectResult(result);
        }
    }
}
