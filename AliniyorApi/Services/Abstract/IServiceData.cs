using AliniyorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliniyorApi.Services
{
    public interface IServiceData
    {
        public List<Cities> GetCitiesAsc();
        public List<Cities> GetCitiesDesc();
        public Cities GetCity(string cityName);
        public Districts GetDistrict(string districtName);
    }
}
