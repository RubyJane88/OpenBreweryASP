// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenBreweryASP.Models;

namespace OpenBreweryASP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenBreweryASP.Models.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("BreweryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("OpenBreweryASP.Models.Entities.Brewery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BreweryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountyProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brewery");

                    b.HasData(
                        new
                        {
                            Id = new Guid("41ba6032-4389-4546-8e83-36a5a58ff72d"),
                            BreweryType = "contract",
                            City = "Alameda",
                            Country = "United States",
                            CreatedAt = new DateTime(2018, 8, 24, 1, 24, 11, 758, DateTimeKind.Local),
                            Latitude = "37.7834497667258",
                            Longitude = "-122.306283180899",
                            Name = "Almanac Beer Company",
                            Phone = "4159326531",
                            PostalCode = "94501-5047",
                            State = "California",
                            Street = "651B W Tower Ave",
                            UpdatedAt = new DateTime(2018, 8, 24, 1, 24, 11, 758, DateTimeKind.Local),
                            WebsiteUrl = "https://almanacbeer.com"
                        },
                        new
                        {
                            Id = new Guid("611be954-ebdb-4d03-9d8b-0a7a867835c0"),
                            BreweryType = "bar",
                            City = "Houston",
                            Country = "United States",
                            CreatedAt = new DateTime(2019, 8, 24, 1, 24, 11, 758, DateTimeKind.Local),
                            Latitude = "29.9515464",
                            Longitude = "-95.5186591",
                            Name = "11 Below Brewing Company",
                            Phone = "2814442337",
                            PostalCode = "77066-3107",
                            State = "Texas",
                            Street = "6820 Bourgeois Rd",
                            UpdatedAt = new DateTime(2019, 8, 24, 1, 24, 11, 758, DateTimeKind.Local),
                            WebsiteUrl = "http://www.11belowbrewing.com"
                        },
                        new
                        {
                            Id = new Guid("e33f0ff9-c919-4b6c-b054-4e1ef1b7bff5"),
                            BreweryType = "large",
                            City = "Bend",
                            Country = "United States",
                            CreatedAt = new DateTime(2019, 9, 24, 1, 24, 11, 758, DateTimeKind.Local),
                            Name = "10 Barrel Brewing Co",
                            Phone = "5415851007",
                            PostalCode = "97701-9847",
                            State = "Oregon",
                            Street = "62970 18th St",
                            UpdatedAt = new DateTime(2019, 9, 24, 1, 24, 11, 758, DateTimeKind.Local),
                            WebsiteUrl = "http://www.10barrel.com"
                        },
                        new
                        {
                            Id = new Guid("26a3c529-ab7c-4f20-873f-156778632582"),
                            BreweryType = "brewpub",
                            City = "Reno",
                            Country = "United States",
                            CreatedAt = new DateTime(2019, 11, 26, 0, 24, 11, 758, DateTimeKind.Local),
                            Latitude = "39.5171702",
                            Longitude = "-119.7732015",
                            Name = "10 Torr Distilling and Brewing",
                            Phone = "7755307014",
                            PostalCode = "89502",
                            State = "Nevada",
                            Street = "490 Mill St",
                            UpdatedAt = new DateTime(2019, 11, 26, 0, 24, 11, 758, DateTimeKind.Local),
                            WebsiteUrl = "http://www.10torr.com"
                        });
                });

            modelBuilder.Entity("OpenBreweryASP.Models.Entities.Address", b =>
                {
                    b.HasOne("OpenBreweryASP.Models.Entities.Brewery", null)
                        .WithMany("Addresses")
                        .HasForeignKey("BreweryId");
                });

            modelBuilder.Entity("OpenBreweryASP.Models.Entities.Brewery", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
