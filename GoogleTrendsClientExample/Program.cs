using System;
using System.Linq;
using System.Net.Security;
using Newtonsoft.Json;

namespace GoogleTrendsClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri server = new Uri("http://localhost:51544/api/InterestOverTime/"); 
            Console.WriteLine("Let`s get some trends!");
            var client = new AsyncHttpClient(server);
            JsonSerializerSettings dateTimeSettings = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
            string keyword = "Obama";
            string additionalParameters = "geo=US";
            additionalParameters += "&startTime=2014-01-01";
            
            /*
             * //keyword - required - type string  - the search term(s) of interest

        //startTime - optional - type Date object - the start of the time range of interest(defaults to new Date('2004-01-01') if not supplied)

        //endTime - optional - type Date object - the end of the time range of interest (defaults to new Date(Date.now()) if not supplied)

        //geo - optional - type string - geocode(s) for a country, region, or DMA depending on the granularity required (defaults to worldwide). For example, geo: 'US-CA-800' will target the Bakersfield, California, United States or geo: 'US' will just target the US. 

        //hl - optional - type string - preferred language code for results (defaults to english)

        //timezone - optional - type number - preferred timezone (defaults to the time zone difference, in minutes, from UTC to current locale (host system settings))

        //category - optional - type number - a number corresponding to a particular category to query within (defaults to all categories), see the category wiki for a complete list

        //granularTimeResolution - optional - type boolean - if true, will try to return results to a finer time resolution (only relevant for startTime and endTime less than one week
             */
            Uri request = client.CreateRequestUri(keyword, additionalParameters);
            var result = client.GetAsync<TimeSeriesResponse>(request).Result;
            Console.WriteLine($"{result.Default.TimelineData.Count} results found. From {result.Default.TimelineData.First().FormattedTime} to {result.Default.TimelineData.Last().FormattedTime} ");
            Console.ReadKey();
        }
    }
}
