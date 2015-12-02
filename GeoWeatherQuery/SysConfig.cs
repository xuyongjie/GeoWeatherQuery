using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoWeatherQuery
{
    public class SysConfig
    {
        private static string _amapWebApiGeocodeKey;
        public static string AmapWebApiGeocodeKey
        {
            get
            {
                if (string.IsNullOrEmpty(_amapWebApiGeocodeKey))
                {
                    return _amapWebApiGeocodeKey = "AmapWebApiGeocodeKey".ToAppSetting();
                }
                return _amapWebApiGeocodeKey;
            }
        }

        private static string _weatherAppId;
        public static string WeatherAppId
        {
            get
            {
                if (string.IsNullOrEmpty(_weatherAppId))
                {
                    return _weatherAppId = "WeatherAppId".ToAppSetting();
                }
                return _weatherAppId;
            }
        }

        public static string _weatherPrivateKey;
        public static string WeatherPrivateKey
        {
            get
            {
                if (string.IsNullOrEmpty(_weatherPrivateKey))
                {
                    return _weatherPrivateKey = "WeatherPrivateKey".ToAppSetting();
                }
                return _weatherPrivateKey;
            }
        }
    }
}
