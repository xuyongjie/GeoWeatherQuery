using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherQueryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherService.WeatherServiceSoapClient client = new WeatherService.WeatherServiceSoapClient("WeatherServiceSoap");
            double longitude, latitude;
            string s;
            while (true)
            {
                Console.WriteLine("Input geo location,'0' to quit");
                s = Console.ReadLine();
                if (s.Equals("0"))
                {
                    break;
                }
                string[] temp = s.Split(new char[] { ',' });
                longitude = double.Parse(temp[0]);
                latitude = double.Parse(temp[1]);
                WeatherService.WeatherInfo info = client.GetWeatherByGeo(longitude, latitude);
                if (info != null)
                {
                    Console.WriteLine(string.Format("Output\nSuccessOrNot:{0}\nAreaId:{1}\nAreaName:{2}\nRefreshTime:{3}\nWeatherInfo(please refrence the api document in the Doc folder to deserialize):\n{4}",info.Success,info.AreaId,info.AreaName,info.RefreshTime.ToString(),info.WeatherJson));
                }
            }
        }
    }
}
