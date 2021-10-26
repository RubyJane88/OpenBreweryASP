using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OpenBreweryASP.Models.Entities;

namespace OpenBreweryASP.Models.Dtos
{
    public sealed class BreweryDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public BreweryType BreweryType { get; set; }
        
        public string Street { get; set; }
        
        public ICollection<Address> Addresses { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County_province { get; set; }
        public string Postal_code { get; set; }

        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Phone { get; set; }
        public string Website_url { get; set; }
        public DateTime Updated_at { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime Created_at { get; set; } = DateTime.Now.ToLocalTime();
    }
}