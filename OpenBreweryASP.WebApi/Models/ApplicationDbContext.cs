
using System;
using Microsoft.EntityFrameworkCore;
using OpenBreweryASP.Models.Dtos;
using OpenBreweryASP.Models.Entities;
using Brewery = OpenBreweryASP.Models.Dtos.BreweryDto;

namespace OpenBreweryASP.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BreweryDto> Breweries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 299,
                    Name = "Almanac Beer Company",
                    BreweryType = BreweryType.Bar,
                    Street = "651B W Tower Ave",
                    Addresses = null,
                    City = "Alameda",
                    State = "California",
                    County_province = null,
                    Postal_code = "94501-5047",
                    Country = "United States",
                    Longitude  = "-122.306283180899",
                    Latitude = "37.7834497667258",
                    Phone = "4159326531",
                    Website_url = "https://almanacbeer.com",
                    Updated_at = Convert.ToDateTime("2018-08-23T23:24:11.758Z").ToLocalTime(),
                    Created_at = Convert.ToDateTime("2018-08-23T23:24:11.758Z").ToLocalTime()
                }
            );
        }
        
        
    }
    
    
}