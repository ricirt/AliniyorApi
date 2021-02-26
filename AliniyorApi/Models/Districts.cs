using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliniyorApi.Models
{
    public class Districts
    {
        public string DistrictName { get; set; }
        public IList<ZipCodes> ZipCodes { get; set; }
    }
}