using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http.Headers;
using unirest_net.http;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;


namespace SheetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        const string SPREADSHEET_ID = "1-SbvcnDoEtNahVT3pXK_Aetcu-I0GLaEmeoqh2_-8Bc";
        const string SHEET_NAME = "Round";

        SpreadsheetsResource.ValuesResource _googleSheetValues;
      
        public WeatherForecastController(helper googleSheetsHelper)
        {
            _googleSheetValues = googleSheetsHelper.Service.Spreadsheets.Values;
        }
       
        [HttpGet]
        public IActionResult Get()
        {
            var range = $"{SHEET_NAME}!A:AB";

            var request = _googleSheetValues.Get(SPREADSHEET_ID, range);
            var response = request.Execute();
            var values = response.Values;
            HttpResponse<string> response2 = Unirest.get("https://eternatepirlanta.p.rapidapi.com/atalay")
              .header("X-RapidAPI-Host", "eternatepirlanta.p.rapidapi.com")
              .header("X-RapidAPI-Key", "4b84bb8186mshff2c2dcedbea6b5p177582jsn14fbead7ecbb")
              .header("Accept", "application/json")
              .asJson<string>();
            Console.WriteLine(response2.Body.ToString());
            
            return Ok(Pro.MapFromRangeData(values));
        }

        [HttpGet("{rowId}")]
        public IActionResult Get(int rowId)
        {
            var range = $"{SHEET_NAME}!A{rowId+1}:AB{rowId}";
            var request = _googleSheetValues.Get(SPREADSHEET_ID, range);
            
            var response = request.Execute();
            var values = response.Values;

            return Ok(Pro.MapFromRangeData(values).FirstOrDefault());
        }
       

        [HttpPost]
        public  IActionResult Post(Item item)
        {
            var range = $"{SHEET_NAME}!A:AB";
            var valueRange = new ValueRange
            {
                Values = Pro.MapToRangeData(item)
            };

            var appendRequest = _googleSheetValues.Append(valueRange, SPREADSHEET_ID, range);
            appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
            appendRequest.Execute();
            /*var client = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://eternatepirlanta.p.rapidapi.com/atalay?="),
                Headers =
                {
                    { "X-RapidAPI-Key", "4b84bb8186mshff2c2dcedbea6b5p177582jsn14fbead7ecbb" },
                    { "X-RapidAPI-Host", "eternatepirlanta.p.rapidapi.com" },
                },
                Content = new StringContent("{  \"id\": \"123\",  \"cert\": \"saaaayigt\",  \"stoneId\": \"string\",  \"certNo\": \"string\",  \"type\": \"string\",  \"carat\": \"string\",  \"shape\": \"string\",  \"clarity\": \"string\",  \"color\": \"string\",  \"cut\": \"string\",  \"price\": \"string\"}")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };*/
            HttpResponse<Pro> response = Unirest.post("https://eternatepirlanta.p.rapidapi.com/atalay?=")
            .header("X-RapidAPI-Key", "4b84bb8186mshff2c2dcedbea6b5p177582jsn14fbead7ecbb")
            .header("X-RapidAPI-Host", "eternatepirlanta.p.rapidapi.com")
            .header("Content-Type", "application/json")
            .body("{\"key1\":\"value\",\"key2\":\"value\"}").asJson<Pro>();


            return CreatedAtAction(nameof(Get), item);
        }

        [HttpPut("{rowId}")]
        public IActionResult Put(int rowId, Item item)
        {
            var range = $"{SHEET_NAME}!A{rowId}:D{rowId}";
            var valueRange = new ValueRange
            {
                Values = Pro.MapToRangeData(item)
            };
            
            var updateRequest = _googleSheetValues.Update(valueRange, SPREADSHEET_ID, range);
            updateRequest.ValueInputOption = UpdateRequest.ValueInputOptionEnum.USERENTERED;
            updateRequest.Execute();

            return NoContent();
        }

        [HttpDelete("{rowId}")]
        public IActionResult Delete(int rowId)
        {
            var range = $"{SHEET_NAME}!A{rowId}:AB{rowId}";
            var requestBody = new ClearValuesRequest();

            var deleteRequest = _googleSheetValues.Clear(requestBody, SPREADSHEET_ID, range);
            deleteRequest.Execute();

            return NoContent();
        }
        /* private static readonly string[] Summaries = new[]
         {
         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
     };

         private readonly ILogger<WeatherForecastController> _logger;

         public WeatherForecastController(ILogger<WeatherForecastController> logger)
         {
             _logger = logger;
         }

         [HttpGet(Name = "GetWeatherForecast")]
         public IEnumerable<WeatherForecast> Get()
         {
             return Enumerable.Range(1, 5).Select(index => new WeatherForecast
             {
                 Date = DateTime.Now.AddDays(index),
                 TemperatureC = Random.Shared.Next(-20, 55),
                 Summary = Summaries[Random.Shared.Next(Summaries.Length)]
             })
             .ToArray();
         }*/
        
    }
    public class conrt
    {
        public async Task apiAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://eternatepirlanta.p.rapidapi.com/atalay?="),
                Headers =
                {
                    { "X-RapidAPI-Key", "4b84bb8186mshff2c2dcedbea6b5p177582jsn14fbead7ecbb" },
                    { "X-RapidAPI-Host", "eternatepirlanta.p.rapidapi.com" },
                },
                Content = new StringContent("{  \"id\": \"123\",  \"cert\": \"saaaayigt\",  \"stoneId\": \"string\",  \"certNo\": \"string\",  \"type\": \"string\",  \"carat\": \"string\",  \"shape\": \"string\",  \"clarity\": \"string\",  \"color\": \"string\",  \"cut\": \"string\",  \"price\": \"string\"}")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                Console.WriteLine(body);
            }
            apiAsync();

        }
    }
   
    
}