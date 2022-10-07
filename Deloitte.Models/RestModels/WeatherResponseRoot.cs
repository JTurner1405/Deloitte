using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Models.RestModels
{
    public class WeatherResponseRoot
    {
        public List<Weather> weather { get; set; }
    }
}
