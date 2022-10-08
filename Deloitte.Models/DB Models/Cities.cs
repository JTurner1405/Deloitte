using Deloitte.Models.RestModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Models.DB_Models
{
    public class Cities
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required,StringLength(100)]
        public string State { get; set; }

        [Required, StringLength(100)]
        public string Country { get; set; }

        [Range(1,5)]
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

        public Cities() { }
        public Cities(Country country)
        {
            Name = country.capital.FirstOrDefault();
            State = country.subregion;
            Country = country.name.common;
            EstimatePopulation = country.population;
            TwoDigitCountryCode = country.cca2;
            ThreeDigitCountryCode = country.cca3;
            CurrencyCode = country.cioc;
        }
    }
}
