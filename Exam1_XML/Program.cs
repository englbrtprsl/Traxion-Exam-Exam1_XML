using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            getdataXML().Wait();
        }

        static async Task getdataXML()
        {
            using (var client = new HttpClient())
            {
                // Update port # in the following line.
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                string apiData = "Japan";
                string apiKey = "c5d1f3535b24f58da88543ff29a5d5e2";

                HttpResponseMessage respon = await client.GetAsync("?q=" + apiData + "&appid=" + apiKey);

                if (respon.StatusCode == HttpStatusCode.OK)
                {
                    dynamic responseData = await respon.Content.ReadAsStringAsync();
                    Console.WriteLine(responseData);
                    //Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(responseData);

                    //Console.WriteLine("City ID: " + obj.id);
                    //Console.WriteLine("City Name: " + obj.name);
                    //Console.WriteLine("City Timezone: " + obj.timezone);
                    //Console.WriteLine("City Code: " + obj.cod);

                    //Console.WriteLine("City Coordinate: Longitute - " + obj.coord.lon);
                    //Console.WriteLine("City Coordinate: Latitude - " + obj.coord.lat);

                }

                Console.ReadKey();
            }

        }
    }
}