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
using Newtonsoft.Json.Linq;
using HotelAppLibrary.Models;

namespace HotelApp.AzureFunction.Functions
{
    public class RoomType
    {
        private readonly IDatabaseData _db;
        public RoomType(IDatabaseData db)
        {
            _db = db;
        }

        [FunctionName("RoomType")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            RoomTypeModel result = null;

            try
            {

                log.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                int roomId = JsonConvert.DeserializeObject<int>(requestBody);

                result = _db.GetRoomTypeById(roomId);

                log.LogInformation("The query executed successfully.");

            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
            }

            return new OkObjectResult(result);
        }
    }
}
