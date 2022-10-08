using Deloitte.Models.DB_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Models.APICalls
{
    public class CreateCityModel
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string State { get; set; }

        [Required, StringLength(100)]
        public string Country { get; set; }

        [Range(1, 5)]
        public int? TouristRating { get; set; }

        public DateTime? DateEstablished { get; set; }

        [StringLength(50)]
        [Required]
        public string EstimatePopulation { get; set; }

        [Required]
        [StringLength(2)]
        public string TwoDigitCountryCode { get; set; }

        [Required]
        [StringLength(3)]
        public string ThreeDigitCountryCode { get; set; }

        [Required]
        [StringLength(5)]
        public string CurrencyCode { get; set; }

        public Cities ConvertToCity()
        {
            return new Cities()
            {
                Name = this.Name,
                State = this.State,
                Country = this.Country,
                TouristRating = this.TouristRating,
                DateEstablished = this.DateEstablished,
                EstimatePopulation = this.EstimatePopulation,
                TwoDigitCountryCode = this.TwoDigitCountryCode,
                ThreeDigitCountryCode = this.ThreeDigitCountryCode,
                CurrencyCode = this.CurrencyCode
            };
        }
    }
}
