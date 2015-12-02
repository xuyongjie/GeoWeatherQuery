using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace GeoWeatherQuery.Entity
{
    public class Node
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Node Parent { get; set; }
        public Dictionary<string, Node> Childs { get; set; }

        private WeatherInfo _weather;
        public WeatherInfo Weather
        {
            get
            {
                if (Childs != null)
                {
                    return Childs.First().Value.Weather;
                }
                else
                {
                    if (_weather == null || DateTime.Now.Subtract(_weather.RefreshTime) > new TimeSpan(1, 0, 0))
                    {
                        _weather = GetWeather();
                    }
                    return _weather;
                }
            }
        }
        private WeatherInfo GetWeather()
        {
            string baseUrl = "http://open.weather.com.cn/data";
            string appId = SysConfig.WeatherAppId;
            string privateKey = SysConfig.WeatherPrivateKey;
            string areaId = this.Id;
            string type = "forecast_v";
            string date = DateTime.Now.ToString("yyyyMMddHHmm");
            string publicKey = string.Format(baseUrl + "/?areaid={0}&type={1}&date={2}&appid={3}", areaId, type, date, appId);
            string key = Util.UrlEncode(Util.HashHMAC(publicKey, privateKey));
            string completeUrl = string.Format(baseUrl + "/?areaid={0}&type={1}&date={2}&appid={3}&key={4}", areaId, type, date, appId.Substring(0, 6), key);

            WebRequest request = WebRequest.Create(completeUrl);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            if (string.IsNullOrEmpty(result) || result.Equals("data error"))
            {
                return new WeatherInfo() { Success = 0, WeatherJson = "查询失败", RefreshTime = DateTime.Now };
            }
            else
            {
                return new WeatherInfo()
                {
                    Success = 1,
                    WeatherJson = result,
                    AreaId = this.Id,
                    AreaName = this.Name,
                    RefreshTime = DateTime.Now
                };
            }
        }
    }
}
