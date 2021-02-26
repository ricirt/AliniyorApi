using AliniyorApi.Models;
using AliniyorApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliniyorApi.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController:ControllerBase
    {
        
        private readonly IServiceData _serviceData;

        public CitiesController(IServiceData serviceData)
        {
            _serviceData = serviceData;
        }
        [HttpGet("GetCitiesAsc")]
        public List<Cities> GetCitiesAsc()
        {
           return _serviceData.GetCitiesAsc();
        }
        [HttpGet("GetCitiesDesc")]
        public List<Cities> GetCitiesDesc()
        {
            return _serviceData.GetCitiesDesc();
        }
        [HttpGet("GetCity/{cityName}")]
        public Cities GetCity(string cityName)
        {
            return _serviceData.GetCity(cityName);
        }
        [HttpGet("GetDistrict/{districtName}")]
        public Districts GetDistrict(string districtName)
        {
            return _serviceData.GetDistrict(districtName);
        }
    }
}
