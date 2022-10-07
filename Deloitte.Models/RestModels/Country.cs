using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Deloitte.Models.RestModels
{
    public class Country
    {
        public CountryName name { get; set; }
        public List<string> capital { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public List<double> latlng { get; set; }
        public double area { get; set; }
        public string flag { get; set; }
        public int population { get; set; }
        public List<string> continents { get; set; }
        public CountryCapitalInfo capitalInfo { get; set; }
        public string cca2 { get; set; }
        public string ccn3 { get; set; }
        public string cca3 { get; set; }
        public string cioc { get; set; }

    }
}
