﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApi.Models;

namespace TravelApi.Migrations
{
    [DbContext(typeof(TravelApiContext))]
    [Migration("20200608202802_Ratings")]
    partial class Ratings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TravelApi.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Rating");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            PlaceId = 1,
                            City = "Heraklion",
                            Country = "Greece",
                            Description = "A beautiful scenic place with delicious food surrounded by warm Aegean waters.",
                            ImageUrl = "https://www.themediterraneantraveller.com/wp-content/uploads/2018/11/greece-heraklion-00032.jpg",
                            Rating = 3
                        },
                        new
                        {
                            PlaceId = 2,
                            City = "Istanbul",
                            Country = "Turkey",
                            Description = " Go to Istanbul if you just have to choose one City in the entire World. All famous tourist attraction in 2 miles diameter. Don't need even transport to go to different attractions. Just walk",
                            ImageUrl = "https://cdn.travelpulse.com/images/65aaedf4-a957-df11-b491-006073e71405/c8f899f1-a4af-4ea3-b5dd-447ebbaeb40e/630x355.jpg",
                            Rating = 3
                        },
                        new
                        {
                            PlaceId = 3,
                            City = "Fes",
                            Country = "Morocco",
                            Description = " Good place to visit if you are already visiting Tangier in Morocco. But do visit Karaveen university that is the oldest university still operational in the World. It started functuning around late 700's. And Yep still going after 1300 years",
                            ImageUrl = "https://www.toursbylocals.com/images/guides/46/46460/202027064423775.jpg",
                            Rating = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
