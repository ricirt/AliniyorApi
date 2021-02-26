using AliniyorApi.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AliniyorApi.Services
{
    public class CsvService : IServiceData
    {

        string path = Path.GetFullPath("~\\wwwroot\\Csv\\sample_data.csv").Replace("~", "");
        public List<Cities> GetCitiesAsc()
        {
            var result = new List<Cities>();
            using (StreamReader fileReader = new StreamReader(path))
            {
                using (var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    csv.Read();

                    var recordCity = new Cities();
                    recordCity.CityName = csv.GetField("CityName");
                    recordCity.CityCode = csv.GetField("CityCode");

                    recordCity.DistrictNames = new List<Districts>();
                    var recordDistrict = new Districts();
                    recordDistrict.DistrictName = csv.GetField("DistrictName");
                    recordCity.DistrictNames.Add(recordDistrict);

                    recordDistrict.ZipCodes = new List<ZipCodes>();
                    var recordZipCode = new ZipCodes();
                    recordZipCode.Code = csv.GetField("ZipCode");
                    recordDistrict.ZipCodes.Add(recordZipCode);

                    result.Add(recordCity);

                    while (csv.Read())
                    {
                        if (result.Last().DistrictNames.Last().DistrictName == csv.GetField("DistrictName"))
                        {
                            var ZipCode = new ZipCodes();
                            ZipCode.Code = csv.GetField("ZipCode");
                            result.Last().DistrictNames.Last().ZipCodes.Add(ZipCode);
                        }
                        else if (result.Last().CityName == csv.GetField("CityName"))
                        {
                            recordDistrict = new Districts();
                            recordDistrict.DistrictName = csv.GetField("DistrictName");
                            recordCity.DistrictNames.Add(recordDistrict);

                            recordDistrict.ZipCodes = new List<ZipCodes>();
                            recordZipCode = new ZipCodes();
                            recordZipCode.Code = csv.GetField("ZipCode");
                            recordDistrict.ZipCodes.Add(recordZipCode);
                        }
                        else
                        {
                            recordCity = new Cities();
                            recordCity.CityName = csv.GetField("CityName");
                            recordCity.CityCode = csv.GetField("CityCode");

                            recordCity.DistrictNames = new List<Districts>();
                            recordDistrict = new Districts();
                            recordDistrict.DistrictName = csv.GetField("DistrictName");
                            recordCity.DistrictNames.Add(recordDistrict);

                            recordDistrict.ZipCodes = new List<ZipCodes>();
                            recordZipCode = new ZipCodes();
                            recordZipCode.Code = csv.GetField("ZipCode");
                            recordDistrict.ZipCodes.Add(recordZipCode);

                            result.Add(recordCity);
                        }
                    }
                }
            }

            result = result.OrderBy(o => o.CityName).ToList();
            return result;
        }
        public List<Cities> GetCitiesDesc()
        {
            var result = new List<Cities>();
            using (StreamReader fileReader = new StreamReader(path))
            {
                using (var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    csv.Read();

                    var recordCity = new Cities();
                    recordCity.CityName = csv.GetField("CityName");
                    recordCity.CityCode = csv.GetField("CityCode");

                    recordCity.DistrictNames = new List<Districts>();
                    var recordDistrict = new Districts();
                    recordDistrict.DistrictName = csv.GetField("DistrictName");
                    recordCity.DistrictNames.Add(recordDistrict);

                    recordDistrict.ZipCodes = new List<ZipCodes>();
                    var recordZipCode = new ZipCodes();
                    recordZipCode.Code = csv.GetField("ZipCode");
                    recordDistrict.ZipCodes.Add(recordZipCode);

                    result.Add(recordCity);

                    while (csv.Read())
                    {
                        if (result.Last().DistrictNames.Last().DistrictName == csv.GetField("DistrictName"))
                        {
                            var ZipCode = new ZipCodes();
                            ZipCode.Code = csv.GetField("ZipCode");
                            result.Last().DistrictNames.Last().ZipCodes.Add(ZipCode);
                        }
                        else if (result.Last().CityName == csv.GetField("CityName"))
                        {
                            recordDistrict = new Districts();
                            recordDistrict.DistrictName = csv.GetField("DistrictName");
                            recordCity.DistrictNames.Add(recordDistrict);

                            recordDistrict.ZipCodes = new List<ZipCodes>();
                            recordZipCode = new ZipCodes();
                            recordZipCode.Code = csv.GetField("ZipCode");
                            recordDistrict.ZipCodes.Add(recordZipCode);
                        }
                        else
                        {
                            recordCity = new Cities();
                            recordCity.CityName = csv.GetField("CityName");
                            recordCity.CityCode = csv.GetField("CityCode");

                            recordCity.DistrictNames = new List<Districts>();
                            recordDistrict = new Districts();
                            recordDistrict.DistrictName = csv.GetField("DistrictName");
                            recordCity.DistrictNames.Add(recordDistrict);

                            recordDistrict.ZipCodes = new List<ZipCodes>();
                            recordZipCode = new ZipCodes();
                            recordZipCode.Code = csv.GetField("ZipCode");
                            recordDistrict.ZipCodes.Add(recordZipCode);
                            result.Add(recordCity);

                        }

                    }
                }
            }
            result.ForEach(x => x.DistrictNames = x.DistrictNames.OrderByDescending(o => o.DistrictName).ToList());

            result = result.OrderByDescending(o => o.CityName).ToList();

            return result;
        }

        public Cities GetCity(string cityName)
        {
            return GetCitiesAsc().Find(x => x.CityName == cityName);
        }

        public Districts GetDistrict(string districtName)
        {
            var result = GetCitiesAsc().Find(x => x.DistrictNames!=null);
            return result.DistrictNames.FirstOrDefault(x=>x.DistrictName == districtName);
        }
    }
}
