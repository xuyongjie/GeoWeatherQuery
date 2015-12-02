namespace GeoWeatherQuery.Entity
{
    public class DistrictInfo
    {
        /// <summary>
        /// 区域Id
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 高德的城市编码
        /// </summary>
        public string AmapCityCode { get; set; }
    }
}
