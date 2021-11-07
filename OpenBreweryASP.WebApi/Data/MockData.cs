using System;
using System.Collections;
using System.Collections.Generic;
using OpenBreweryASP.Models.Dtos;
using OpenBreweryASP.Models.Entities;

namespace OpenBreweryASP.Data
{
    public static class MockData
    {
        public static IEnumerable<BreweryDto> GetAllBreweries()
        {
            var breweryDtos = new List<BreweryDto>
            {
                new()
                {
                    Id = new Guid("41ba6032-4389-4546-8e83-36a5a58ff72d"),
                    Name = "Almanac Beer Company",
                    BreweryType = "contract",
                    Street = "651B W Tower Ave",
                    Addresses = null,
                    City = "Alameda",
                    State = "California",
                    CountyProvince = null,
                    PostalCode = "94501-5047",
                    Country = "United States",
                    Longitude = "-122.306283180899",
                    Latitude = "37.7834497667258",
                    Phone = "4159326531",
                    WebsiteUrl = "https://almanacbeer.com",
                    UpdatedAt = Convert.ToDateTime("2018-08-23T23:24:11.758Z").ToLocalTime(),
                    CreatedAt = Convert.ToDateTime("2018-08-23T23:24:11.758Z").ToLocalTime()

                },
                new()
                {
                    Id = new Guid("e33f0ff9-c919-4b6c-b054-4e1ef1b7bff5"),
                    Name = "10 Barrel Brewing Co",
                    BreweryType = "large",
                    Street = "62970 18th St",
                    Addresses = null,
                    City = "Bend",
                    State = "Oregon",
                    CountyProvince = null,
                    PostalCode = "97701-9847",
                    Country = "United States",
                    Longitude = null,
                    Latitude = null,
                    Phone = "5415851007",
                    WebsiteUrl = "http://www.10barrel.com",
                    UpdatedAt = Convert.ToDateTime("2019-09-23T23:24:11.758Z").ToLocalTime(),
                    CreatedAt = Convert.ToDateTime("2019-09-23T23:24:11.758Z").ToLocalTime()
                },

                new()
                {
                    Id = new Guid("26a3c529-ab7c-4f20-873f-156778632582"),
                    Name = "10 Torr Distilling and Brewing",
                    BreweryType = "brewpub",
                    Street = "490 Mill St",
                    Addresses = null,
                    City = "Reno",
                    State = "Nevada",
                    CountyProvince = null,
                    PostalCode = "89502",
                    Country = "United States",
                    Longitude = "-119.7732015",
                    Latitude = "39.5171702",
                    Phone = "7755307014",
                    WebsiteUrl = "http://www.10torr.com",
                    UpdatedAt = Convert.ToDateTime("2019-11-25T23:24:11.758Z").ToLocalTime(),
                    CreatedAt = Convert.ToDateTime("2019-11-25T23:24:11.758Z").ToLocalTime()
                },

                new()
                {
                    Id = new Guid("22ed8c89-9204-4db8-b268-750034626b27"),
                    Name = "14th Star Brewing",
                    BreweryType = "micro",
                    Street = "133 N Main St Ste 7",
                    Addresses = null,
                    City = "Saint Albans",
                    State = "Vermont",
                    CountyProvince = null,
                    PostalCode = "05478-1735",
                    Country = "United States",
                    Longitude = null,
                    Latitude = null,
                    Phone = "8025285988",
                    WebsiteUrl = "http://www.14thstarbrewing.com",
                    UpdatedAt = Convert.ToDateTime("2011-11-25T23:24:11.758Z").ToLocalTime(),
                    CreatedAt = Convert.ToDateTime("2011-11-25T23:24:11.758Z").ToLocalTime()
                }
            };
            return breweryDtos;
        }

        public static Brewery GetOneBrewery()
        {
            var brewery = new Brewery
            {
                Id = new Guid("ba30fefd-88ad-4d24-8ff9-c93b16c23632"),
                Name = "10-56 Brewing Company",
                BreweryType = "micro",
                Street = "400 Brown Cir",
                Addresses = null,
                City = "Knox",
                State = "Indiana",
                CountyProvince = null,
                PostalCode = "46534",
                Country = "United States",
                Longitude = "-86.627954",
                Latitude = "41.289715",
                Phone = "6308165790",
                WebsiteUrl = null,
                UpdatedAt = Convert.ToDateTime("2010-11-25T23:24:11.758Z").ToLocalTime(),
                CreatedAt = Convert.ToDateTime("2010-11-25T23:24:11.758Z").ToLocalTime()
            };
            return brewery;
        }

        public static BreweryDto GetOneBreweryDto()
        {
            var breweryDto = new BreweryDto
            {
                Id = new Guid("ba30fefd-88ad-4d24-8ff9-c93b16c23632"),
                Name = "Alpha Brewing Company",
                BreweryType = "contract",
                Street = "400 Brown Cir",
                Addresses = null,
                City = "New York",
                State = "New York",
                CountyProvince = null,
                PostalCode = "46934",
                Country = "United States",
                Longitude = "-86.627959",
                Latitude = "41.289715",
                Phone = "6308165790",
                WebsiteUrl = null,
                UpdatedAt = Convert.ToDateTime("2010-11-25T23:24:11.758Z").ToLocalTime(),
                CreatedAt = Convert.ToDateTime("2010-11-25T23:24:11.758Z").ToLocalTime()
            };
            return breweryDto;
        }
    }
}
