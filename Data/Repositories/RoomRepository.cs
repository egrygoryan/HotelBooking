using HotelBooking.Data.Context;
using HotelBooking.Data.Entities;
using HotelBooking.Data.Repositories.Interfaces;
using HotelBooking.Models.Constants;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data.Repositories;

public sealed class RoomRepository(BookingContext ctx) : IRoomRepository
{
    public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(AppartmentType? appartmentType = null)
    {
        if (appartmentType is null)
        {
            return await ctx.Rooms
                 .Include(x => x.RoomType)
                 .Where(x => !x.IsOccupied)
                 .ToListAsync();
        }

        return await ctx.Rooms
                 .Include(x => x.RoomType)
                 .Where(x => x.RoomType.Type == appartmentType.ToString())
                 .Where(x => !x.IsOccupied)
                 .ToListAsync();
    }

    public async Task SetRoomOccupiedAsync(Room toBook)
    {
        //update it here, not in servicemodel layer(specifically in model class)
        //just for simplicity of code
        toBook.IsOccupied = true;

        ctx.Rooms.Update(toBook);
        await ctx.SaveChangesAsync();
    }

    public async Task<Room> GetByIdAsync(int roomNumber)
    {
        var room = await ctx.Rooms.FirstOrDefaultAsync(x => x.Number == roomNumber);
        return room ?? throw new ArgumentException($"No such room with ID: {roomNumber}");
    }
}
