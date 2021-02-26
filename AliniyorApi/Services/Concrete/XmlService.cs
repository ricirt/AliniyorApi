using AliniyorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace AliniyorApi.Services
{
    public class XmlService : IServiceData
    {
        string path = Path.GetFullPath("~\\wwwroot\\Xml\\sample_data.xml").Replace("~", "");


        public List<Cities> GetCitiesAsc()
        {

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodeList = xmlDoc.SelectNodes("//AddressInfo/City");
            var cities = new List<Cities>();

            foreach (XmlNode item in nodeList)
            {
                var city = new Cities
                {
                    CityName = item.Attributes["name"].Value,
                    CityCode = item.Attributes["code"].Value,
                };

                var districts = new List<Districts>();

                foreach (XmlNode districtXml in item)
                {

                    var districtObj = new Districts();
                    districtObj.DistrictName = districtXml.Attributes["name"].Value;
                    var codes = new List<ZipCodes>();
                    foreach (XmlNode code in districtXml)
                    {
                        codes.Add(new ZipCodes
                        {
                            Code = code.Attributes["code"].Value
                        });
                    }
                    districtObj.ZipCodes = codes;

                    districts.Add(districtObj);
                }
                city.DistrictNames = districts;
                cities.Add(city);
            }
            return cities;
        }

        public List<Cities> GetCitiesDesc()
        {

            var cities = GetCitiesAsc();
            
            cities.ForEach(x => x.DistrictNames = x.DistrictNames.OrderByDescending(o => o.DistrictName).ToList());

            cities = cities.OrderByDescending(o => o.CityName).ToList();
            return cities;
        }

        public Cities GetCity(string cityName)
        {
            return GetCitiesAsc().Find(x => x.CityName == cityName);
        }

        public Districts GetDistrict(string districtName)
        {
            var result = GetCitiesAsc().Find(x => x.DistrictNames != null);
            return result.DistrictNames.FirstOrDefault(x => x.DistrictName == districtName);
        }
    }
}
