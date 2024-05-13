using HotelBooking.Data.Context;
using HotelBooking.Data.Entities;
using HotelBooking.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data.Repositories;

public sealed class BookingRepository(BookingContext bookingCtx) : IBookingRepository
{
    public async Task AddAsync(Booking booking)
    {
        await bookingCtx.AddAsync(booking);
        await bookingCtx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Booking booking)
    {
        bookingCtx.Bookings.Remove(booking);
        await bookingCtx.SaveChangesAsync();
    }

    public async Task<IEnumerable<Booking>> GetRelatedAsync(int guestId)
    {
        return await bookingCtx.Bookings
            .Include(x => x.Guest)
            .Where(x => x.Guest.Id == guestId)
            .ToListAsync();
    }

    public async Task<Booking> GetByIdAsync(int id)
    {
        var booking = await bookingCtx.Bookings
            .Include(x => x.RoomType)
            .Include(x => x.Guest)
            .FirstOrDefaultAsync(x => x.Id == id);
        return booking ?? throw new ArgumentException($"No such booking with ID: {id}");
    }
}
