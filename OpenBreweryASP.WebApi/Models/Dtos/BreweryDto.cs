using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OpenBreweryASP.Models.Entities;

namespace OpenBreweryASP.Models.Dtos
{
    public sealed class BreweryDto
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; init; }

        public string BreweryType { get; set; }
        
        public string Street { get; init; }
        
        public ICollection<Address> Addresses { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountyProvince { get; set; }
        public string PostalCode { get; set; }

        public string Country { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string Phone { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
    }
}