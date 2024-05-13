using HotelBooking.Data.Context;
using HotelBooking.Data.Entities;
using HotelBooking.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data.Repositories;

public sealed class GuestRepository(BookingContext ctx) : IGuestRepository
{
    public async Task<Guest> GetByIdAsync(int id)
    {
        var guest = await ctx.Guests.FirstOrDefaultAsync(x => x.Id == id);
        return guest ?? throw new ArgumentException($"No such user with ID: {id}");
    }

    public async Task UpdateAsync(Guest guest)
    {
        ctx.Guests.Update(guest);
        await ctx.SaveChangesAsync();
    }
}
