using GeoWeatherQuery.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;

namespace GeoWeatherQuery
{
    /// <summary>
    /// Summary description for WeatherService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WeatherService : System.Web.Services.WebService
    {

        public static Node Root = null;

        [WebMethod(Description = "根据经纬度获取天气")]
        public WeatherInfo GetWeatherByGeo(double longitude, double latitude)
        {
            if (Root == null)
            {
                Root = new Node() { Parent = null };
                ReadDistrictData();
            }
            return GetWeatherByDistrict(GetDistrictByGeo(longitude, latitude, 10));
        }

        private void FormatDistrict(DistrictInfo dist)
        {
            if (!string.IsNullOrEmpty(dist.District))
            {
                if (dist.District.Equals("浦东新区") || dist.District.Equals("滨海新区") || dist.District.Equals("呼市郊区")
                    || dist.District.Equals("尖草坪区") || dist.District.Equals("小店区")
                    || dist.District.Equals("淮阴区") || dist.District.Equals("淮安区")
                    || dist.District.Equals("黄山区") || dist.District.Equals("黄山风景区")
                    || dist.District.Equals("赫山区")
                    || dist.District.Equals("通化县") || dist.District.Equals("本溪县")
                    || dist.District.Equals("辽阳县") || dist.District.Equals("建平县")
                    || dist.District.Equals("承德县") || dist.District.Equals("大同县")
                    || dist.District.Equals("五台县") || dist.District.Equals("伊宁县")
                    || dist.District.Equals("芜湖县") || dist.District.Equals("南昌县")
                    || dist.District.Equals("上饶县") || dist.District.Equals("吉安县")
                    || dist.District.Equals("衡阳县") || dist.District.Equals("邵阳县")
                    || dist.District.Equals("遵义县") || dist.District.Equals("宜宾县"))//含同名区，特定县不做转换
                {

                }
                else
                {
                    int smallestLength = dist.District.Length;
                    if (smallestLength == 2 && dist.District[smallestLength - 1].Equals('县'))//两字县不做转换
                    {

                    }
                    else if (dist.District[smallestLength - 1].Equals('市') || dist.District[smallestLength - 1].Equals('区') || dist.District[smallestLength - 1].Equals('县'))
                    {
                        dist.District = dist.District.Remove(smallestLength - 1);
                    }
                }
            }
        }

        private WeatherInfo GetWeatherByDistrict(DistrictInfo District)
        {
            if (District == null)
            {
                return null;
            }
            FormatDistrict(District);
            if (District.Nation == Root.Name)
            {
                if (Root.Childs.ContainsKey(District.AmapCityCode))
                {
                    Node city = Root.Childs[District.AmapCityCode];
                    if (city.Childs.ContainsKey(District.District))
                    {
                        Node district = city.Childs[District.District];
                        return district.Weather;
                    }
                    else
                    {
                        return city.Weather;
                    }
                }
                else
                {
                    return Root.Weather;
                }
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 高德逆地理编码，根据经纬度获取位置描述
        /// Post
        /// http://restapi.amap.com/v3/geocode/regeo?key=b34d6e34c5ab8bab7ff3075d2a12ca5c&location=113.921076,22.499654&radius=10&extensions=all&coordsys=gps
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lon">经度</param>
        /// <param name="radius">精确度</param>
        /// <returns></returns>
        private DistrictInfo GetDistrictByGeo(double longitude, double latitude, double radius)
        {
            ///TEMP
            ///return new DistrictInfo() { AreaId = "101191004", Name = "灌云", District = "连云港", Province = "江苏", Nation = "中国" };

            try
            {
                string url = string.Format("http://restapi.amap.com/v3/geocode/regeo?key={0}&location={1},{2}&radius={3}&extensions=all&coordsys=autonavi", SysConfig.AmapWebApiGeocodeKey, longitude, latitude, radius);
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                var responeStream = request.GetResponse();
                StreamReader reader = new StreamReader(responeStream.GetResponseStream());
                string jsonStr = reader.ReadToEnd();
                JObject jobject = (JObject)JsonConvert.DeserializeObject(jsonStr);
                DistrictInfo district = new DistrictInfo();
                district.Nation = "中国";
                district.Province = jobject["regeocode"]["addressComponent"]["province"].ToString();
                district.City = jobject["regeocode"]["addressComponent"]["city"].ToString();
                district.AmapCityCode = jobject["regeocode"]["addressComponent"]["citycode"].ToString();
                district.District = jobject["regeocode"]["addressComponent"]["district"].ToString();
                return district;
            }
            catch
            {
                return null;
            }
        }

        private void ReadDistrictData()
        {

            using (FileStream fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/NormalDistrictData.xlsx")))
            {
                XSSFWorkbook wk = new XSSFWorkbook(fs);
                ISheet sheet = wk.GetSheetAt(0);
                for (int i = 1; i < sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row != null)
                    {
                        DistrictInfo info = new DistrictInfo();
                        info.AreaId = row.GetCell(0).ToString();
                        info.District = row.GetCell(2).ToString();
                        info.City = row.GetCell(4).ToString();
                        info.Province = row.GetCell(6).ToString();
                        info.Nation = row.GetCell(8).ToString();
                        info.AmapCityCode = row.GetCell(9).ToString();
                        InsertIntoTree(info, Root);
                    }
                }
            }
        }

        private void InsertIntoTree(DistrictInfo info, Node root)
        {
            root.Name = info.Nation;
            if (root.Childs == null)
            {
                root.Childs = new Dictionary<string, Node>();
            }
            if (!root.Childs.ContainsKey(info.AmapCityCode))
            {
                root.Childs.Add(info.AmapCityCode, new Node() { Id = info.AmapCityCode, Name = info.City, Parent = root });
            }
            if (root.Childs[info.AmapCityCode].Childs == null)
            {
                root.Childs[info.AmapCityCode].Childs = new Dictionary<string, Node>();
            }
            if (!root.Childs[info.AmapCityCode].Childs.ContainsKey(info.District))
            {
                root.Childs[info.AmapCityCode].Childs.Add(info.District, new Node() { Id = info.AreaId, Name = info.District, Parent = root.Childs[info.AmapCityCode] });
            }
        }
    }
}
