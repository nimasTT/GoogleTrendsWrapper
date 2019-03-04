using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleTrendsASPCoreServer.Model
{
    public class Request
    {
        public Request(string keyword, DateTime? startTime, DateTime? endTime, string geo, string hl, int? timezone, int? category, bool? granularTimeResolution)
        {
            this.keyword = keyword ?? throw new ArgumentNullException();
            if (startTime == null)
            {
                this.startTime = new DateTime(2004, 1, 1);
            }
            else
            {
                this.startTime = startTime.Value;
            }
            if (endTime == null)
            {
                this.endTime = DateTime.Now;
            }
            else
            {
                this.endTime = endTime.Value;
            }

            this.geo = geo;
            this.hl = hl;
            this.timezone = timezone;
            this.category = category;
            this.granularTimeResolution = granularTimeResolution;
        }

        //keyword - required - type string or array - the search term(s) of interest
        public string keyword { get; private set; }

        //startTime - optional - type Date object - the start of the time range of interest(defaults to new Date('2004-01-01') if not supplied)
        public DateTime startTime { get; private set; }

        //endTime - optional - type Date object - the end of the time range of interest (defaults to new Date(Date.now()) if not supplied)
        public DateTime endTime { get; private set; }

        //geo - optional - type string or array - geocode(s) for a country, region, or DMA depending on the granularity required (defaults to worldwide). For example, geo: 'US-CA-800' will target the Bakersfield, California, United States or geo: 'US' will just target the US. Passing geo: ['US-CA, US-VA'], keyword: ['wine', 'peanuts'] will search for wine in California and peanuts in Virginia.
        public string geo { get; private set; }

        //hl - optional - type string - preferred language code for results (defaults to english)
        public string hl { get; private set; }

        //timezone - optional - type number - preferred timezone (defaults to the time zone difference, in minutes, from UTC to current locale (host system settings))
        public int? timezone { get; private set; }

        //category - optional - type number - a number corresponding to a particular category to query within (defaults to all categories), see the category wiki for a complete list
        public int? category { get; private set; }

        //granularTimeResolution - optional - type boolean - if true, will try to return results to a finer time resolution (only relevant for startTime and endTime less than one week)
        public bool? granularTimeResolution { get; private set; }

    }
}
