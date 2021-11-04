#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBreweryASP.Models.Entities
{
    [Table("Brewery")]
    public class Brewery
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string BreweryType { get; set; }
        
        public string Street { get; set; }
        public ICollection<Address>? Addresses { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? CountyProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        
        // [Column(TypeName = "decimal(7,4)")]
        public string? Longitude { get; set; }
        
        // [Column(TypeName = "decimal(7,4)")]
        public string? Latitude { get; set; }
        
        [Phone]
        public string Phone { get; set; }
        
        [Url]
        public string WebsiteUrl { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
        
        
    }

 
}