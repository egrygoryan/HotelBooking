using HotelBooking.Data.Entities;
using HotelBooking.Models.Constants;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var john = new Guest() { Id = 1, Email = "john_doe@yahoo.com", Name = "John Doe" };
        var larry = new Guest() { Id = 2, Email = "larry_bird@bing.com", Name = "Larry Bird" };

        var studio = new RoomType() { Id = 1, Description = "a small apppartment", MaxGuests = 1, Price = 100, Type = AppartmentType.Studio.ToString() };
        var luxe = new RoomType() { Id = 2, Description = "luxe appartment for a company", MaxGuests = 3, Price = 300, Type = AppartmentType.Luxe.ToString() };
        var penthouse = new RoomType() { Id = 3, Description = "a huge penthouse", MaxGuests = 6, Price = 800, Type = AppartmentType.Penthouse.ToString() };

        var room1 = new Room() { Number = 1, IsOccupied = true, RoomTypeId = 1 };
        var room2 = new Room() { Number = 2, IsOccupied = true, RoomTypeId = 2 };
        var room3 = new Room() { Number = 3, IsOccupied = false, RoomTypeId = 3 };


        var bookingJohn = new Booking()
        {
            Id = 1,
            CheckInDate = new DateTime(2024, 05, 24),
            CheckOutDate = new DateTime(2024, 05, 27),
            CreateDate = DateTime.Now,
            GuestId = 1,
            NumberOfGuests = 1,
            RoomTypeId = 1
        };
        var bookingLarry = new Booking()
        {
            Id = 2,
            CheckInDate = new DateTime(2024, 08, 10),
            CheckOutDate = new DateTime(2024, 09, 27),
            CreateDate = DateTime.Now,
            GuestId = 2,
            NumberOfGuests = 2,
            RoomTypeId = 2
        };

        modelBuilder.Entity<Guest>().HasData(john, larry);
        modelBuilder.Entity<RoomType>().HasData(studio, luxe, penthouse);
        modelBuilder.Entity<Room>().HasData(room1, room2, room3);
        modelBuilder.Entity<Booking>().HasData(bookingJohn, bookingLarry);
    }
}
