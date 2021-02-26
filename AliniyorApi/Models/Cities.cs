using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliniyorApi.Models
{
    public class Cities
    {
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public IList<Districts> DistrictNames { get; set; }
    }
}
