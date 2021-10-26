#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenBreweryASP.Models.Entities
{
    [Table("Brewery")]
    public sealed class Brewery
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public BreweryType Brewery_type { get; set; }
        
        public string Street { get; set; }
        public ICollection<Address>? Addresses { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? County_province { get; set; }
        public string Postal_code { get; set; }
        public string Country { get; set; }
        
        [Column(TypeName = "decimal(7,4)")]
        public decimal Longitude { get; set; }
        
        [Column(TypeName = "decimal(7,4)")]
        public decimal Latitude { get; set; }
        
        [Phone]
        public string Phone { get; set; }
        
        [Url]
        public string Website_url { get; set; }
        public DateTime Updated_at { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime Created_at { get; set; } = DateTime.Now.ToLocalTime();
        
        
    }

 
}