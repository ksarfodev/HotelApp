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
using HotelAppLibrary.Models;
using System.Collections.Generic;

namespace HotelApp.AzureFunction.Functions
{
    public class RoomSearch
    {
        private readonly IDatabaseData _db;

        List<RoomTypeModel> _result = new();

        public RoomSearch(IDatabaseData db)
        {
            _db = db;
        }

        [FunctionName("RoomSearch")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {

                log.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                DateRange data = JsonConvert.DeserializeObject<DateRange>(requestBody);

                _result = _db.GetAvailableRoomTypes(data.StartDate, data.EndDate);

                log.LogInformation($"The query executed successfully.");

            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
            }

            return new OkObjectResult(_result);
        }
    }
}
