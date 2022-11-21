using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class ClimaData
    {
        public string city_name { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone { get; set; }
        public Data_W[] data { get; set; }
    }

    public class Data_W
    {
        public float ts { get; set; }
        public DateTime timestamp_local { get; set; }
        public DateTime timestamp_utc { get; set; }
        public string datetime { get; set; }
        public float snow { get; set; }
        public float snow_depth { get; set; }
        public float precip { get; set; }
        public float temp { get; set; }
        public float dewpt { get; set; }
        public float max_temp { get; set; }
        public float min_temp { get; set; }
        public float app_max_temp { get; set; }
        public float app_min_temp { get; set; }
        public float rh { get; set; }
        public float clouds { get; set; }
        public Weather weather { get; set; }
        public float slp { get; set; }
        public float pres { get; set; }
        public float uv { get; set; }
        public string max_dhi { get; set; }
        public float vis { get; set; }
        public float pop { get; set; }
        public float moon_phase { get; set; }
        public int sunrise_ts { get; set; }
        public int sunset_ts { get; set; }
        public int moonrise_ts { get; set; }
        public int moonset_ts { get; set; }
        public string pod { get; set; }
        public float wind_spd { get; set; }
        public int wind_dir { get; set; }
        public string wind_cdir { get; set; }
        public string wind_cdir_full { get; set; }
    }

    public class Weather
    {
        public string icon { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

}
