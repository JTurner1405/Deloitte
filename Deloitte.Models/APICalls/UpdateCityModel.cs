using Deloitte.Models.DB_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Models.APICalls
{
    public class UpdateCityModel
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int? TouristRating { get; set; }

        public DateTime? DateEstablished { get; set; }

        [StringLength(50)]
        [Required]
        public string EstimatePopulation { get; set; }

        public Cities ConvertToCity(Cities cities)
        {
            cities.TouristRating = this.TouristRating;
            cities.DateEstablished = this.DateEstablished;
            cities.EstimatePopulation = this.EstimatePopulation;

            return cities;
        }
    }
}
