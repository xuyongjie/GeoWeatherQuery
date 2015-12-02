using System;

namespace GeoWeatherQuery.Entity
{
    public class WeatherInfo
    {
        /// <summary>
        /// 成功与否,0失败，1成功
        /// </summary>
        public int Success { get; set; }
        /// <summary>
        /// 完整天气json
        /// </summary>
        public string WeatherJson { get; set; }
        /// <summary>
        /// 中国天气数据平台的区域编码（县区）
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        /// 中国天气数据平台的区域名（县区）
        /// </summary>
        public string AreaName { get; set; }

        public DateTime RefreshTime { get; set; }
    }
}
